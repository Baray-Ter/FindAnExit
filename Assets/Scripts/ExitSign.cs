using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitSign : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        foreach(ContactPoint2D hitPos in other.contacts)
        {
            if (hitPos.normal == new Vector2(0, -1))
            {
                SceneManager.LoadScene(5);
            }
        }
    }
}
