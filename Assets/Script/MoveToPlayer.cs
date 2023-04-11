using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player; //���� ��� �÷��̾�
    [SerializeField]
    private float moveSpeed = 3.0f; //���� �ӵ�
    private Movement2D movement;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //�±װ� "Plyer" �̸� ������� ����
    }

    private void FixedUpdate()
    {
       
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

       
    }
}
