using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWave : MonoBehaviour
{
    [SerializeField] EnemySpawner spawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            spawner.TriggerWave();
            Destroy(gameObject);
        }
    }
}
