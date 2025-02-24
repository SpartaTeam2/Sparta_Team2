using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float minX = -4f;  
    public float maxX = 3f;   
    public float minY = -2f;  
    public float maxY = 13f;   
    public float smoothSpeed = 0.2f; 

    void FixedUpdate()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;
        pos.x = target.position.x;
        pos.y = target.position.y;

        
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed);

    }
}
