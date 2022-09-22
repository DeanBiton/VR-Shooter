using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabEnemy;
    [SerializeField] private float cooldown = 5;

    void Start()
    {
        StartCoroutine(generateEnemies());
    }

    void Update()
    {
        
    }

    public IEnumerator generateEnemies()
    {
        while(true)
        {
            GameObject enemy = (GameObject)Instantiate(prefabEnemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(cooldown);
        }
    }
}
