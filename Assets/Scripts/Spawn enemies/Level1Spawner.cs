using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Spawner : EnemySpawner
{
    int waveNum = 1;

    override public void TriggerWave()
    {
        switch (waveNum)
        {
            case 1:
                wave1();
                break;
            case 2:
                wave2();
                break;
            case 3:
                wave3();
                break;
            case 4:
                wave4();
                break;
        }

        waveNum++;
    }

    private void wave1()
    {
        int [][] arr =
        {
            new int[] {0,1,0}, 
        };

        float [] cooldowns = {3.0f};

        createWave(arr, cooldowns);
    }

    private void wave2()
    {
        int [][] arr =
        {
            new int[] {0,1}, 
            new int[] {1,0},
        };

        float [] cooldowns = {3.0f, 3.0f};

        createWave(arr, cooldowns);
    }

    private void wave3()
    {
        int [][] arr =
        {
            new int[] {0}, 
            new int[] {1},
            new int[] {0},
        };

        float [] cooldowns = {5.0f, 5.0f, 5.0f};

        createWave(arr, cooldowns);
    }

    private void wave4()
    {
        int [][] arr =
        {
            new int[] {0,1}, 
            new int[] {1,0},
            new int[] {1,0},
        };

        float [] cooldowns = {5.0f, 5.0f, 5.0f};

        createWave(arr, cooldowns);
    }
    /*
    private void wave1()
    {
        int[] arr1 = new int[] {0,1,0};
        StartCoroutine(generateEnemies(arr1, children[0], 5.0f));
    }

    private void wave2()
    {
        int[] arr1 = new int[] {0,1};
        StartCoroutine(generateEnemies(arr1, children[1], 5.0f));
        int[] arr2 = new int[] {1,0};
        StartCoroutine(generateEnemies(arr2, children[2], 5.0f));
    }

    private void wave3()
    {
        int[] arr1 = new int[] {0};
        StartCoroutine(generateEnemies(arr1, children[3], 5.0f));
        int[] arr2 = new int[] {1};
        StartCoroutine(generateEnemies(arr2, children[4], 5.0f));
        int[] arr3 = new int[] {0};
        StartCoroutine(generateEnemies(arr3, children[5], 5.0f));
    }

    private void wave4()
    {
        int[] arr1 = new int[] {0,1};
        StartCoroutine(generateEnemies(arr1, children[6], 5.0f));
        int[] arr2 = new int[] {1,0};
        StartCoroutine(generateEnemies(arr2, children[7], 5.0f));
        int[] arr3 = new int[] {1,0};
        StartCoroutine(generateEnemies(arr3, children[8], 5.0f));
    }*/
}
