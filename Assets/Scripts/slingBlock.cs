using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slingBlock : MonoBehaviour
{
    public GameObject player;
    SpringJoint2D sp2D;
    Rigidbody2D rb2D;

    private void Start()
    {
        sp2D = GetComponent<SpringJoint2D>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.SetParent(this.transform);
        }
    }
}
