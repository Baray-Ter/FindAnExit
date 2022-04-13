using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed;
    public Transform startPos;

    Vector3 nextPos;

    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pointA.position)
        {
            nextPos = pointB.position;
        }
        if (transform.position == pointB.position)
        {
            nextPos = pointA.position;

        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pointA.position, pointB.position);
    }
}
