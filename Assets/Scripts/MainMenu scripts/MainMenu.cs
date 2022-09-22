using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject MainPanel;
    private GameObject HowToPlayPanel;
    private GameObject PlayPanel;
    private GameObject QuitPanel;

    void Start()
    {
        MainPanel = transform.GetChild(0).gameObject;
        HowToPlayPanel = transform.GetChild(1).gameObject;
        PlayPanel = transform.GetChild(2).gameObject;
        QuitPanel = transform.GetChild(3).gameObject;
    }

    void Update()
    {
        
    }

    public void playBtn()
    {
        MainPanel.SetActive(false);
        PlayPanel.SetActive(true);
    }

    public void level1Btn()
    {
        SceneManager.LoadScene("LevelOne");
    }
}
