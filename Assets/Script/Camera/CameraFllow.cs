using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFllow : MonoBehaviour
{
    [SerializeField]
    private Transform target; // 추적할 대상
    [SerializeField]
    private float smoothing = 5.0f; // 이동속도

    Vector3 offset; // 대상 간의 거리 

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        // 대상 위치에 맞게 이동
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
