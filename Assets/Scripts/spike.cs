using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.transform.position = new Vector3(22,1.2f,0);
    }
}
