using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player; //추적 대상 플레이어
    [SerializeField]
    private float moveSpeed = 3.0f; //추적 속도
    private Movement2D movement;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //태그가 "Plyer" 이면 대상으로 설정
    }

    private void FixedUpdate()
    {
       
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

       
    }
}
