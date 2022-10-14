using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private GameObject MainPanel;
    private GameObject HowToPlayPanel;
    private GameObject PlayPanel;
    private GameObject QuitPanel;
    private bool start = true;
    [SerializeField] private Camera mainCamera;
    private SoundManager soundManager;

    void Start()
    {
        MainPanel = transform.GetChild(0).gameObject;
        HowToPlayPanel = transform.GetChild(1).gameObject;
        PlayPanel = transform.GetChild(2).gameObject;
        QuitPanel = transform.GetChild(3).gameObject;
        Time.timeScale = 1;
        soundManager = GameObject.FindWithTag("Sound").GetComponent<SoundManager>();
    }

    void Update()
    {
        if(start)
        {
            soundManager.mainMenuBackground();
            start = false;
        }
        if(Input.anyKeyDown)
        {
            click();
        }
    }

    private void unlockLevels()
    {
        int maxLevelIndex = PlayerPrefs.GetInt("maxLevelCompleted", 0);
        GameObject[] levels = GameObject.FindGameObjectsWithTag("Level");
        for(int i = 0; i <= maxLevelIndex && i < levels.Length; i++)
        {
            levels[i].transform.GetChild(1).gameObject.SetActive(false);
        }
        for(int i = maxLevelIndex + 1; i < levels.Length; i++)
        {
            levels[i].GetComponent<Button>().interactable = false;
        }
    }

    public void playBtn()
    {
        MainPanel.SetActive(false);
        PlayPanel.SetActive(true);
        unlockLevels();
    }

    public void howToPlayBtn()
    {
        MainPanel.SetActive(false);
        HowToPlayPanel.SetActive(true);
    }

    public void backBtn()
    {
        MainPanel.SetActive(true);
        HowToPlayPanel.SetActive(false);
        PlayPanel.SetActive(false);
        QuitPanel.SetActive(false);
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

    public void level1Btn()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void level2Btn()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    private void click()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        ray.origin = mainCamera.transform.position;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                Button button = hit.collider.GetComponentInParent<Button>();
                if(button.interactable)
                {
                    button.onClick.Invoke();
                    soundManager.laser();
                }
            }
        }
    }
}
