using UnityEngine;

public class redBlock : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        State.jumpForce = 13f;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        State.jumpForce = 10f;
    }
}
