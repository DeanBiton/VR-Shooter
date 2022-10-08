using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    private GameObject HeartsPanel;
    private GameObject DeadPanel;
    private GameObject EndLevelPanel;

    void Start()
    {
        HeartsPanel = transform.GetChild(0).gameObject;
        DeadPanel = transform.GetChild(1).gameObject;
        EndLevelPanel = transform.GetChild(2).gameObject;
    }

    void Update()
    {
        
    }
}
