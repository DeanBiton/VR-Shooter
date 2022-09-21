using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Gun gun;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform gunStart;

    void Start()
    {
        //gun = RedGun(mainCamera, gunStart, 1);
    }

    void Update()
    {
        if(Input.anyKeyDown)//if(Input.GetMouseButtonDown(0))//if(Input.anyKeyDown)
        {
            gun.shoot();
        }
    }
}
