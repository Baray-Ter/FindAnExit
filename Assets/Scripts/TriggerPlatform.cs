using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed;
    public float newSpeed;

    Vector3 nextPos;
    public Transform startPos;
    private bool movePlatformA;

    //Platform momentum
    public static bool positionJumped;

    //small delay for b point
    private float goOn = 0.5f;

    void Start()
    {
        nextPos = pointB.position;
        newSpeed = 2f;
        movePlatformA = false;
        //GameObject.Find("movementAndLongJump").GetComponent<movementAndLongJump>(playerSpeed);
    }

    private void Update()
    {
        movePlatform();

        if (transform.position == pointB.position)
        {
            goOn -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (! other.gameObject.CompareTag("Player"))
        {
            return;
        }
        movePlatformA = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        movePlatformA = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pointA.position, pointB.position);
    }

    private void movePlatform()
    {
        if (movePlatformA)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

            if (transform.position == pointA.position)
            {
                nextPos = pointB.position;
                movePlatformA = false;
                goOn = 0.5f;
            }

            if (transform.position == pointB.position && goOn <= 0f)
            {
                nextPos = pointA.position;
                speed = 2.9f;
            }

            if (nextPos == pointB.position)
            {
                speed += newSpeed;
            }
        }
    }
}
