using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class separeteButtonsScript : MonoBehaviour
{
    public GameObject BigDoor;
    public GameObject DoorWay;
    public GameObject showExit;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Table"))
        {
            State.onTouch = true;
        }

        if (other.gameObject.CompareTag("table2"))
        {
            State.onTouch2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Table"))
        {
            State.onTouch = false;     
        }

        if (other.gameObject.CompareTag("table2"))
        {
            State.onTouch2 = false;
        }
    }

    private void Update()
    {
        if (State.onTouch2 && State.onTouch)
        {
            Door();
        }
    }

    private void Door()
    {
        if (BigDoor.transform.position != DoorWay.transform.position)
        {
            BigDoor.transform.position = Vector3.MoveTowards(BigDoor.transform.position, DoorWay.transform.position, 5f * Time.deltaTime);
        }

        if (BigDoor.transform.position == DoorWay.transform.position)
        {
            showExit.SetActive(true);
        }
        
    }
}
