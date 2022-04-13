using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitV2 : MonoBehaviour
{
    private int sceneID;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sceneID = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneID + 1);
        }
    }
}
