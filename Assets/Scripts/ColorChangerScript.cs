using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ColorChangerScript : MonoBehaviour
{
    public TextMeshPro tmo;

    public Transform pos2;
    public GameObject movingDoor;
    public float speed;
    public GameObject destroyItSelf;
    private bool truee;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            truee = true;
            
            //you can destroy collider of the object writing col
            Destroy(destroyItSelf);
        }

        if (other.gameObject.CompareTag("Door") && truee)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void Update()
    {
        if (truee)
        {
            movingDoor.transform.position = Vector3.MoveTowards(movingDoor.transform.position, pos2.position, speed * Time.deltaTime);
        }
    }
}
