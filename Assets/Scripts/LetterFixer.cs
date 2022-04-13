using UnityEngine;
using UnityEngine.SceneManagement;

public class LetterFixer : MonoBehaviour
{
    public GameObject Door;

    private GameObject letters;

    private int lettersNeedToTurn = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        letterFixxerV2(other.gameObject.name);
    }

    private void letterFixxerV2(string fixxer)
    {
        letters = GameObject.Find(fixxer);

        if (letters.transform.eulerAngles != new Vector3(0,0,0))
        {
            letters.transform.eulerAngles = Vector3.forward * 0;

            lettersNeedToTurn++;

            if (lettersNeedToTurn > 2) Door.SetActive(true);
        }
    }
}
