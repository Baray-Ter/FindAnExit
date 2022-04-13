using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicButton : MonoBehaviour
{
    public Component myLight;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            myLight.gameObject.SetActive(true);
        }
    }
}
