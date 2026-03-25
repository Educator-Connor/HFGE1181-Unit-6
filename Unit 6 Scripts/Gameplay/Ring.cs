using System;
using Unity.VisualScripting;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public bool isActive;
    public GameObject activeSprite;
    public GameObject inactiveSprite;
   
    private void Awake()
    {
        isActive = false;
        activeSprite.SetActive(true);
        inactiveSprite.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.CompareTag("Player"))
        {
            isActive = true;
            activeSprite.SetActive(false);
            inactiveSprite.SetActive(true);
        }
    }
    
}
