using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int damage = 1;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 총알에 부딪힌 오브젝트의 태그가 "Enemy" 이면
        if (collision.CompareTag("Enemy"))
        {
            //적 hp 
            collision.GetComponent<EnemyHP>().EnemyTakeDamage(damage);
            // 총알삭제
            Destroy(gameObject);

        }
    }
}
