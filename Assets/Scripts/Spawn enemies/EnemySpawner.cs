using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    protected List<Transform> children;

    void Start()
    {
        children = new List<Transform>();

        foreach (Transform child in transform)
        {
            children.Add(child);
        }
    }

    public IEnumerator generateEnemies(int[] enemyNumbers, Transform spawnPoint, float cooldown)
    {
        foreach (int num in enemyNumbers)
        {
            Instantiate(enemies[num], spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(cooldown);
        }
    }

    abstract public void TriggerWave();
}
