using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFllow : MonoBehaviour
{
    [SerializeField]
    private Transform target; // ������ ���
    [SerializeField]
    private float smoothing = 5.0f; // �̵��ӵ�

    Vector3 offset; // ��� ���� �Ÿ� 

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        // ��� ��ġ�� �°� �̵�
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
