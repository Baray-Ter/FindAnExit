using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpUp : MonoBehaviour
{
    public Transform Player;
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Player.position.y < -15)
        {
            Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y * -1);
            rb2d.velocity = new Vector2(rb2d.velocity.x, -5f);
        }
    }

    private void OnBecameInvisible()
    {
        if (rb2d.gravityScale > 3)
        {
            rb2d.gravityScale = 1.5f;
        }
    }
}
