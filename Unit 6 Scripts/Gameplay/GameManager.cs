using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform player;
    public Transform checkpoint;
    public int lives;
    public int score;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0; 
    }

    public void LoadPlayerToCheckpoint()
    {
        player.position = checkpoint.position;
    }

    public void LoseLife()
    {
        lives--;
        if (lives == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void UpdateScore(int value)
    {
        score += value;
    }
    
}
