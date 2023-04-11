using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    private int damage = 2;
    private AudioSource audio;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
       transform.Rotate(Vector3.forward *  500 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �Ѿ˿� �ε��� ������Ʈ�� �±װ� "Enemy" �̸�
        if (collision.CompareTag("Enemy"))
        {
            //�� hp 
            collision.GetComponent<EnemyHP>().EnemyTakeDamage(damage);
            audio.Play();
            // �Ѿ˻���
           // Destroy(gameObject);

        }
    }
}
