using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.CompareTag("Player"))
        {
            GameManager.Instance.checkpoint = transform;
        }
    }
}
