using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int damage = 1;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �Ѿ˿� �ε��� ������Ʈ�� �±װ� "Enemy" �̸�
        if (collision.CompareTag("Enemy"))
        {
            //�� hp 
            collision.GetComponent<EnemyHP>().EnemyTakeDamage(damage);
            // �Ѿ˻���
            Destroy(gameObject);

        }
    }
}
