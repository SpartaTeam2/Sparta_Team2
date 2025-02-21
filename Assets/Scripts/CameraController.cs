using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float minX = -4f;  // 카메라가 이동할 수 있는 X축 최소값
    public float maxX = 3f;   // 카메라가 이동할 수 있는 X축 최대값
    public float minY = -2f;  // 카메라가 이동할 수 있는 Y축 최소값
    public float maxY = 13f;   // 카메라가 이동할 수 있는 Y축 최대값
    public float smoothSpeed = 0.2f; // 카메라 이동 속도

    void FixedUpdate()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;
        pos.x = target.position.x;
        pos.y = target.position.y;

        // 카메라 위치를 제한 영역 내로 조정
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed);

    }
}
