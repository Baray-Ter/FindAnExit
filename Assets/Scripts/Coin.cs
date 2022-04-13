using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    protected AudioSource collected;

    protected virtual void Start()
    {
        collected = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScore(coinValue);

            collected.Play();

            //2. parametreyi girmemizin sebebi objenin sesi oynatmadan yok olmas�
            Destroy(this.gameObject, collected.clip.length);
        }
    }
}
