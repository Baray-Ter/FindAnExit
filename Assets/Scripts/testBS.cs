using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBS : MonoBehaviour
{
    public Rigidbody2D playersRigidBody2D;
    [SerializeField] private GameObject playerFind;

    private float toLeft;

    private void OnCollisionEnter2D(Collision2D other)
    {
        playerFind = GameObject.FindGameObjectWithTag("Player");
        playersRigidBody2D = playerFind.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionExit2D(Collision2D other)
    {   
        if (other.relativeVelocity.x > 0)
        {
            playersRigidBody2D.AddRelativeForce(Vector2.left * -2 * other.relativeVelocity.x);
            //playersRigidBody2D.AddRelativeForce(Vector2.left * 15 * other.relativeVelocity);
        } 

        if (other.relativeVelocity.x < 0)
        {
            //playersRigidBody2D.AddRelativeForce(Vector2.right * 15 * -other.relativeVelocity.x);
            playersRigidBody2D.AddRelativeForce(Vector2.right * 2 * other.relativeVelocity.x);
        }
        
        playersRigidBody2D = null;
        
        //if you make a code rewiew or something please tell me a better way
        //if you're on a video please cencor the mail adress
        //m.barayter@hotmail.com
    }
}
