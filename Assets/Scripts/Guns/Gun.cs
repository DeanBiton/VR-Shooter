using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour 
{
    private int minLevel = 1;
    private int maxLevel = 3;
    [SerializeField] private int level;

    [SerializeField] protected Transform gunStart;
    [SerializeField] protected Camera mainCamera;
    protected SoundManager soundManager;

    void Start()
    {
        soundManager = GameObject.FindWithTag("Sound").GetComponent<SoundManager>();
    }

    public void shoot()
    {
        switch(level)
        {
            case 1:
                shootLevel1();
                break;
            case 2:
                //act
                break;
            case 3:
                //act
                break;
        }

        soundManager.laser();
    }

    protected abstract void shootLevel1();

    public void increaseLevel()
    {
        if(level != maxLevel)
            level++;
    }

    public void decreaseLevel()
    {
        if(level != minLevel)
            level--;
    }
}
