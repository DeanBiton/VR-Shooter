using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEndLevel : MonoBehaviour
{
    [SerializeField] private LevelUI levelUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelUI.levelCompleted();
            Destroy(gameObject);
        }
    }
}
