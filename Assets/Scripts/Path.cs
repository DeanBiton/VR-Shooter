using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerForward;
    protected List<Transform> points;
    int currentPoint = 1;
    float MoveSpeed = 1.5f;

    void Start()
    {
        points = new List<Transform>();

        foreach (Transform child in transform)
        {
            points.Add(child);
        }
    }

    void Update()
    {
        if(currentPoint < points.Count)
        {
            if(withinRange(player.transform, points[currentPoint]))
            {
                currentPoint++;
            }
            else
            {
                playerForward.LookAt(points[currentPoint]);
                player.transform.position += playerForward.forward * MoveSpeed * Time.deltaTime;
            }
        }
    }

    bool withinRange(Transform transform, Transform point)
    {
        float range = 0.1f;
        if( (Mathf.Abs(transform.position.x - point.position.x) < range) && 
            (Mathf.Abs(transform.position.y - point.position.y) < range) &&
            (Mathf.Abs(transform.position.z - point.position.z) < range))
            return true;
        else
            return false;
    }
}
