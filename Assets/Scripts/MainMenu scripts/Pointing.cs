using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointing : MonoBehaviour
{
    [SerializeField] private LineRenderer laserLine;
    [SerializeField] private Camera mainCamera;
    
    void Start()
    {
        laserLine.enabled = true;
    }

    void Update()
    {
        Vector3 startPoint = (mainCamera.transform.TransformDirection(Vector3.right) + mainCamera.transform.TransformDirection(Vector3.forward));
        Vector3 endPoint = (mainCamera.transform.TransformDirection(Vector3.forward) * 200);

        Vector3[] points = new Vector3[] {startPoint, endPoint};
        laserLine.SetPositions(points);

        if(Input.GetAxis("Mouse X")<0)
            transform.RotateAround(transform.position,Vector3.up,-1f);
        if(Input.GetAxis("Mouse X")>0)
            transform.RotateAround(transform.position,Vector3.up,1f);
        if(Input.GetAxis("Mouse Y")<0)
            transform.RotateAround(transform.position,Vector3.right,-1f);
        if(Input.GetAxis("Mouse Y")>0)
            transform.RotateAround(transform.position,Vector3.right,1f);
    }
}
