using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Gun gun;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform gunStart;
    [SerializeField] private LevelUI levelUI;
    private SoundManager soundManager;
    private int currentHealth;

    void Start()
    {
        currentHealth = 3;
        soundManager = GameObject.FindWithTag("Sound").GetComponent<SoundManager>();
    }

    void Update()
    {
        if(Input.anyKeyDown && !levelUI.endGame)
        {
            gun.shoot();
        }
    }

    public void Damage()
    {
        if(currentHealth != 0)
        {
            soundManager.hurt();
            currentHealth -= 1;
            levelUI.updateHealth(currentHealth);
            if(currentHealth == 0)
            {
                levelUI.levelFailed();
            }
        }
    }
}
