using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Gun gun;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform gunStart;
    private int currentHealth;

    void Start()
    {
        currentHealth = 3;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))//if(Input.GetMouseButtonDown(0))//if(Input.anyKeyDown)
        {
            gun.shoot();
        }
    }

    public void Damage()
    {
        currentHealth -= 1;
        Debug.Log("The player has been attacked");
        if(currentHealth == 0)
        {
            Debug.Log("Dead");
        }
    }
}
