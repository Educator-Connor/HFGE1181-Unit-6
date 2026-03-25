using UnityEngine;

public class KillOnCollision : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.LoadPlayerToCheckpoint();
            GameManager.Instance.LoseLife();
        }
    }
}
