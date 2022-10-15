using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour 
{
    [SerializeField] protected Transform gunStart;
    [SerializeField] protected Camera mainCamera;
    protected SoundManager soundManager;

    [SerializeField] private GameObject[] bullets;
    [SerializeField] private Material[] materials;
    //private float [][] rotations = new float[2][];

    private int bulletSpeed = 60;
    private GameObject currentBullet;
    private int index;
    void Start()
    {
        soundManager = GameObject.FindWithTag("Sound").GetComponent<SoundManager>();
        currentBullet = bullets[0];
        //rotations[0] = new float[] {0,0,0};
        //rotations[1] = new float[] {0,1,0};
    }

    public void setBullet(string bulletColor)
    {
        switch(bulletColor) 
        {
        case "red":
            index = 0;
            break;
        case "purple":
            index = 1;
            break;
        default:
            index = 0;
            break;
        }

        currentBullet = bullets[index];
        gameObject.GetComponent<MeshRenderer> ().material = materials[index];
    }

    public void shoot()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        ray.origin = mainCamera.transform.position;

        GameObject bullet = (GameObject)Instantiate(currentBullet, gunStart.transform.position, currentBullet.transform.rotation);
        Destroy(bullet, 5f);

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(1000); 

        bullet.transform.LookAt(targetPoint);
        //bullet.transform.Rotate(rotations[index][0], rotations[index][1], rotations[index][2]);
        bullet.GetComponent<Rigidbody>().velocity = ( targetPoint - gunStart.transform.position ).normalized * bulletSpeed;
        soundManager.laser();
    }
}
