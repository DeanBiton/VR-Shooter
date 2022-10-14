using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    private SoundManager soundManager;
    private GameObject HeartsPanel;
    private GameObject DeadPanel;
    private GameObject EndLevelPanel;
    private bool start = true;
    [SerializeField] private GameObject[] heartFills;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    public bool endGame =  false;

    void Start()
    {
        HeartsPanel = transform.GetChild(0).gameObject;
        DeadPanel = transform.GetChild(1).gameObject;
        EndLevelPanel = transform.GetChild(2).gameObject;
        soundManager = GameObject.FindWithTag("Sound").GetComponent<SoundManager>();
    }

    void Update()
    {
        if(start)
        {
            soundManager.levelStart();
            start = false;
        }
        if(Input.anyKeyDown && endGame)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void updateHealth(int currentHealth)
    {
        for(int i = 0; i < currentHealth; i++)
        {
            heartFills[i].SetActive(true);
        }
        for(int i = currentHealth; i < heartFills.Length; i++)
        {
            heartFills[i].SetActive(false);
        }
    }

    public void levelFailed()
    {
        DeadPanel.SetActive(true);
        Time.timeScale = 0;
        endGame =  true;
    }

    public void levelCompleted(int level)
    {
        EndLevelPanel.SetActive(true);
        Time.timeScale = 0;
        if(level > PlayerPrefs.GetInt("maxLevelCompleted", 0))
        {
            PlayerPrefs.SetInt("maxLevelCompleted", level);
        }
        endGame =  true;
    }
}
