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
        // 총알에 부딪힌 오브젝트의 태그가 "Enemy" 이면
        if (collision.CompareTag("Enemy"))
        {
            //적 hp 
            collision.GetComponent<EnemyHP>().EnemyTakeDamage(damage);
            audio.Play();
            // 총알삭제
           // Destroy(gameObject);

        }
    }
}
