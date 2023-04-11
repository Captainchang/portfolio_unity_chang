using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeat : MonoBehaviour
{
    private int heal = 1;
    private AudioSource meataudio;
    private void Awake()
    {
        meataudio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 고기에 부딪힌 오브젝트의 태그가 "Player" 이면
        if (collision.CompareTag("Player"))
        {
            //플레이어 hp 회복
            collision.GetComponent<PlayerHP>().EatMeat(heal);
            // 고기 삭제
            Destroy(gameObject);

            
        }
    }
}
