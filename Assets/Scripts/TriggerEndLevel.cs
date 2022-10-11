using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEndLevel : MonoBehaviour
{
    [SerializeField] private LevelUI levelUI;
    [SerializeField] private int level;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelUI.levelCompleted(level);
            Destroy(gameObject);
        }
    }
}
