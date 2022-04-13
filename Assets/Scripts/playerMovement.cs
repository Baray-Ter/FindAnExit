using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    private float moveInput;
    Rigidbody2D rb2d;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    private bool isItgrounded;
    [SerializeField] private float checkRadius;
    public Joystick playersJoystick;


    //[SerializeField]private float State.State.jumpForce;

    [SerializeField]private float jumpTime;
    [SerializeField]private float jumpTimeValue;
    private bool Jumped = false;

    private bool facingRight = true;
    public Transform Player;




    private FixedJoint2D fixedJ2D;





    [SerializeField] private Rigidbody2D playersRigidBody2D;
    [SerializeField] private Rigidbody2D blackSquareFind;
    [SerializeField] private GameObject playerFind;


    void Start()
    {
        playersJoystick = Joystick.FindObjectOfType<Joystick>();

        rb2d = GetComponent<Rigidbody2D>();

        jumpTimeValue = jumpTime;

        playersJoystick = Joystick.FindObjectOfType<Joystick>();

    }


    void Update()
    {
        if (State.playerSpeed > 10f) 
        {
            StartCoroutine(waitForIt());

            if (State.playerSpeed < 10f)
            {
                State.playerSpeed = 10f; 
            }
        }

        Debug.Log(State.jumpForce + "jumpForce");
    }

    private void FixedUpdate()
    {
        isItgrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        //moveInput = Input.GetAxisRaw("Horizontal");
        moveInput = playersJoystick.Horizontal;

        rb2d.velocity = new Vector2(moveInput * State.playerSpeed, rb2d.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
        OnBecameInvisible();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpTime--;
        }  

        workAlways();
    }

    //sağa solo döndürme 
    void Flip()
    {
        facingRight = !facingRight;
        
        Vector3 Scaler = transform.localScale;

        Scaler.x *= -1;
         
        transform.localScale = Scaler;
    }

    //karakterin geri gelmesi
    private void OnBecameInvisible()
    {
        if (Player.position.y < -20)
        {
            Player.transform.position = new Vector3(-5, 10);
        }
    }








    IEnumerator waitForIt()
    {
        State.playerSpeed -= 0.35f;

        yield return new WaitForSeconds(1.2f);
    }

    
    public void jumpHigh(){

        if (isItgrounded)
        {
            rb2d.gravityScale = -10f;

            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);

            rb2d.AddForce(Vector2.up * State.jumpForce * 2, ForceMode2D.Impulse);

            Jumped = true;
        }

        workAlways();
    }

    public void fall(){
        
        Jumped = false;

        rb2d.gravityScale = 6;
        
        if (Jumped == false)
        {
            jumpTime = jumpTimeValue;
        }
    }

    private void workAlways(){

        if(jumpTime > 0 && Jumped)
        {
            jumpTime--; 
        }

        if(jumpTime <= 0)
        {
            rb2d.gravityScale = 5;
        }
    }



    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("blackSquare"))
        {
            State.blackBlockOnTouch = true;
            
            blackSquareFind = other.rigidbody;

            addFixedJoint2D();          
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {

        playerFind = GameObject.FindGameObjectWithTag("Player");

        playersRigidBody2D = playerFind.GetComponent<Rigidbody2D>();

        State.blackBlockOnTouch = true;





        deleteFixedJoint2DComponent();

        if (other.gameObject.CompareTag("blackSquare"))
        {
            addFixedJoint2D();
        }

    }






    private void addFixedJoint2D(){
        
        if (moveInput == 0 && State.blackBlockOnTouch == true)
        {
            if (gameObject.GetComponent<FixedJoint2D>() == null)
            {
                FixedJoint2D fx2D = gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;

                fx2D.connectedBody = blackSquareFind;

                fx2D.breakForce = float.PositiveInfinity;

                fx2D.enableCollision = true;

            }
        }
    }














    private void deleteFixedJoint2DComponent(){  

        if (playersJoystick.Horizontal != 0f /*UwU*/)
        {
            fixedJ2D = gameObject.GetComponent<FixedJoint2D>();
            
            Destroy(fixedJ2D);
        }   
    }






    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Player.transform.parent = other.gameObject.transform;
        }
    }

    //does nothing for now
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("fastPlatform"))
        {
            fastPlatform();
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Player.transform.parent = null;
        }
    }


    private void fastPlatform()
    {
        State.playerSpeed = 50f;
    }



    /*
        if (/*Input.GetKeyDown(KeyCode.Space) && isItgrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * State.jumpForce, ForceMode2D.Impulse);
            
            Jumped = true;
            jumpTimeValue = jumpTime;

            rb2d.gravityScale = 0f;
        }
        if (/*Input.GetKey(KeyCode.Space) && jumpTimeValue > 0 && Jumped)
        {
            rb2d.velocity = Vector2.up * State.jumpForce;
            jumpTimeValue -= Time.deltaTime;
        }


        if (/*Input.GetKeyUp(KeyCode.Space) || jumpTimeValue < 0)
        {
            Jumped = false;
            rb2d.gravityScale = 3f;
        }


        afterJumped = TriggerPlatform.positionJumped;

        if (afterJumped)
        {
            State.playerSpeed = 15f;
        }
    */
}












        /*

        //döngüyü kırmanın bir yolunu bulamadım
        do
        {
            if (isItgrounded)
            {
                rb2d.gravityScale = -1f;
                jumpTime -= 0.1f;

                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                rb2d.AddForce(Vector2.up * State.jumpForce, ForceMode2D.Impulse);

                Debug.Log("works but it shouldn't");

                if (0f > jumpTime)
                {
                    Debug.Log("this should work");
                    break;
                }

                return;

            }
            break;
            
        } while (false);
        */
