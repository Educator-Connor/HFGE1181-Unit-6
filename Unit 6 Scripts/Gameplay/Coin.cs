using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    public void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.CompareTag("Player"))
        {
            GameManager.Instance.UpdateScore(value);
            this.gameObject.SetActive(false);
        }
    }
}
