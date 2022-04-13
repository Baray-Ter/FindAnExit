using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.EventSystems;

public class standPlayer : MonoBehaviour
{
    public Joystick playersJoystick;
    private FixedJoint2D fixedJ2D;
    private float moveInput;


    public FixedJoystick playersFixedJoystick;
    private float playersFixedJoystickHorizantal;

    [SerializeField] private Rigidbody2D playersRigidBody2D;
    [SerializeField] private GameObject playerFind;


    void Start()
    {
        playersJoystick = Joystick.FindObjectOfType<Joystick>();
        //EventTrigger trigger = GetComponent<EventTrigger>();
    }

    private void FixedUpdate()
    {
        moveInput = playersJoystick.Horizontal;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        playerFind = GameObject.FindGameObjectWithTag("Player");
        playersRigidBody2D = playerFind.GetComponent<Rigidbody2D>();
        State.blackBlockOnTouch = true;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        //addFixedJoint2D();
        deleteFixedJoint2DComponent();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        deleteFixedJoint2DComponent();
        //onJumpButton = true;
        playersRigidBody2D = null;
        State.blackBlockOnTouch = false;
    }
    /*
    private void //addFixedJoint2D(){
        
        if (moveInput == 0 && State.blackBlockOnTouch == true)
        {
            if (gameObject.GetComponent<FixedJoint2D>() == null)
            {
                FixedJoint2D fx2D = gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
            }

            if (gameObject.GetComponent<FixedJoint2D>())
            {
                fixedJ2D = GetComponent<FixedJoint2D>();
                fixedJ2D.connectedBody = playersRigidBody2D; 

                fixedJ2D.breakForce = float.PositiveInfinity;
                fixedJ2D.enableCollision = true;
            }
        }
    }
    */

    private void deleteFixedJoint2DComponent(){  

        if (playersFixedJoystick.Horizontal != 0f /*UwU*/)
        {
            Destroy(fixedJ2D);
        }   
    }

    public void deleteOnJump(){

        //onJumpButton = false;
        fixedJ2D = GetComponent<FixedJoint2D>();
        Destroy(fixedJ2D);

    }
}