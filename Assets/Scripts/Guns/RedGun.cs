using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class RedGun : Gun
{
    [SerializeField] GameObject prefabBullet;
    private int bulletSpeed = 50;
    protected override void shootLevel1()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        ray.origin = mainCamera.transform.position;

        GameObject bullet = (GameObject)Instantiate(prefabBullet, gunStart.transform.position, prefabBullet.transform.rotation);
        Destroy(bullet, 5f);

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(1000); 

        bullet.transform.LookAt(targetPoint);
        bullet.transform.Rotate(90, 0, 0);
        bullet.GetComponent<Rigidbody>().velocity = ( targetPoint - gunStart.transform.position ).normalized * bulletSpeed;
    }
}
