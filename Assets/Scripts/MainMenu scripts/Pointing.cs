using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointing : MonoBehaviour
{
    private LineRenderer laserLine;
    [SerializeField] private Camera mainCamera;
    
    void Start()
    {
        laserLine = gameObject.GetComponent<LineRenderer>();
        laserLine.enabled = true;
    }

    void Update()
    {
        Vector3 rayOrigin = mainCamera.ViewportToWorldPoint (new Vector3 (.5f, .3f, 0)); 
        laserLine.SetPositions()

        if(Input.GetAxis("Mouse X")<0)
            transform.RotateAround(transform.position,Vector3.up,-1f);
        if(Input.GetAxis("Mouse X")>0)
            transform.RotateAround(transform.position,Vector3.up,1f);
    }

}
