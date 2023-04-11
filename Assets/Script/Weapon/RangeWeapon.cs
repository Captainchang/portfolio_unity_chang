using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : MonoBehaviour
{
    private int damage = 1;
    private void Update()
    {
        transform.Rotate(Vector3.back * 150 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �Ѿ˿� �ε��� ������Ʈ�� �±װ� "Enemy" �̸�
        if (collision.CompareTag("Enemy"))
        {
            //�� hp 
            collision.GetComponent<EnemyHP>().EnemyTakeDamage(damage);
        }
    }
}
