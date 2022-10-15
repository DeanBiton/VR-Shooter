using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    [SerializeField] private Gun gun;
    [SerializeField] private string colorName;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Shootable")
        {
            gun.setBullet(colorName);
            Destroy(gameObject); 
        }
    }
}
