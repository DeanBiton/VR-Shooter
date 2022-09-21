using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float m_Speed = 0.03f;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
            transform.position += transform.forward * m_Speed;
        if(Input.GetKey(KeyCode.DownArrow))
            transform.position += -transform.forward * m_Speed;
        if(Input.GetKey(KeyCode.RightArrow))
            transform.position += transform.right * m_Speed;
        if(Input.GetKey(KeyCode.LeftArrow))
            transform.position += -transform.right * m_Speed;
        if(Input.GetAxis("Mouse X")<0)
            transform.RotateAround(transform.position,Vector3.up,-1f);
        if(Input.GetAxis("Mouse X")>0)
            transform.RotateAround(transform.position,Vector3.up,1f);
    }
}
