using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject[] imgLives;
    public Image[] imgRings;
    public Ring[] rings;
    public Sprite activeSprite, inactiveSprite;
    public TextMeshProUGUI txtScore;
    public TextMeshProUGUI txtTime;
    private float timer;

    public GameObject hudUI;
    public GameObject pauseMenuUI;
    public GameObject winScreenUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Start()
    {
        pauseMenuUI.SetActive(false);
        hudUI.SetActive(true);
        winScreenUI.SetActive(false);
        
        foreach (Image imgRing in imgRings)
        {
            imgRing.sprite = inactiveSprite;
        }

        foreach (GameObject imgLife in imgLives)
        {
            imgLife.SetActive(true);
        }
        
        timer = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        UpdateScore();
        UpdateRings();
        UpdateLives(GameManager.Instance.lives);
        timer += Time.deltaTime;
    }

    public void UpdateLives(int lives)
    {
        foreach (GameObject imgLife in imgLives)
        {
            imgLife.SetActive(false);
        }

        for (int i = 0; i < lives; i++)
        {
            imgLives[i].SetActive(true);
        }
    }

    public void UpdateTimer()
    {
        txtTime.text = "Timer: " + timer.ToString("00.00");
    }

    public void UpdateScore()
    {
        txtScore.text = "Score: " + GameManager.Instance.score.ToString("000");
    }

    public void UpdateRings()
    {
        int i = 0;
        int counter = 0;
        foreach (Ring ring in rings)
        {
            if (ring.isActive)
            {
                imgRings[i].sprite = activeSprite;
                counter++;
            }

            i++;
        }

        if (counter ==  rings.Length)
        {
            Time.timeScale = 0;
            pauseMenuUI.SetActive(false);
            hudUI.SetActive(false);
            winScreenUI.SetActive(true);
            
        }

    }


}
