using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public BoxCollider2D hitBox;
    public GameObject trueDoor;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Table"))
        {
            Debug.Log("XD");
            hitBox.enabled = true;
            trueDoor.SetActive(true);
        }
    }

    void OntriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Table"))
        {
            Debug.Log("XD");
            hitBox.enabled = false;
            trueDoor.SetActive(false);
        }
    }


}
