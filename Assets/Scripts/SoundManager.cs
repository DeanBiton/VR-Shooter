using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource backgroundAudio;
    private AudioSource enemyAppearAudio; 
    private AudioSource hurtAudio; 
    private AudioSource laserAudio; 
    private AudioSource levelStartAudio; 

    void Start()
    {
        backgroundAudio = transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        enemyAppearAudio = transform.GetChild(1).gameObject.GetComponent<AudioSource>();
        hurtAudio = transform.GetChild(2).gameObject.GetComponent<AudioSource>();
        laserAudio = transform.GetChild(3).gameObject.GetComponent<AudioSource>();
        levelStartAudio = transform.GetChild(4).gameObject.GetComponent<AudioSource>();
    }

    public void mainMenuBackground()
    {
        backgroundAudio.volume = 0.15f;
        backgroundAudio.loop = true;
        backgroundAudio.Play();
    }

    public void levelStart()
    {
        levelStartAudio.Play();
        backgroundAudio.volume = 0.05f;
        backgroundAudio.loop = true;
        backgroundAudio.Play();  
    }

    public void enemyAppear()
    {
        enemyAppearAudio.volume = 0.1f;
        enemyAppearAudio.Play();
    }

    public void hurt()
    {
        hurtAudio.Play();
    }

    public void laser()
    {
        laserAudio.volume = 0.5f;
        laserAudio.Play();
    }
}
