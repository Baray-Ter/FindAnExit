using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpBlock : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playersRigidBody2D;
    [SerializeField] private GameObject playerFind;

    private void Awake()
    {
        playerFind = GameObject.FindGameObjectWithTag("Player");
        playersRigidBody2D = playerFind.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Debug.Log(playersRigidBody2D.velocity.y);
    }

    //mavi bloktan zıplarsan zıplamanın Rigidbody2D'si normal zıplamanın ki ile çelişiyor
    //mavi bloktan zıplmayı engelleye bilirsin çözüm olarak
    
    void OnTriggerEnter2D(Collider2D other)
    {
        playersRigidBody2D.AddForce(Vector2.up * 40f, ForceMode2D.Impulse);
    }

    private void OnTriggerExit2D(Collider2D other)
    {

    }
}
