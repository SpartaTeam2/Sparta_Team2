using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class Follow : MonoBehaviour
{
    public Transform target;
    public RectTransform hpBar;
    public Camera mainCamera;
    public Vector3 offset;


    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 worldPosition = target.position + offset;  // 대상 위치 + 오프셋
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(worldPosition); // 씬 카메라

        Vector2 screenPosition = new Vector2(
            ((viewportPosition.x * mainCamera.pixelWidth) - (mainCamera.pixelWidth * 0.5f)),
            ((viewportPosition.y * mainCamera.pixelHeight) - (mainCamera.pixelHeight * 0.5f)));

        hpBar.anchoredPosition = screenPosition;
    }
}
