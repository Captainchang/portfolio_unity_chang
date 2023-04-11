using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 3; //최대 체력
    private float currentHP; // 현재 체력
    private int exp = 1;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private Enemy enemy;
    [SerializeField]
    GameObject Meatprefab;
    int spawnMeatRandom;
    public static int Meatlevel = 0;
    public float MaxHP => maxHP;   // maxHP변수에 접근 프로퍼티 (Get)
    public float CurrentHP => currentHP;  //currenHP변수에 접근 프로퍼티 (Get)

    private void Awake()
    {
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();      
    }
    public void EnemyTakeDamage(float damage)
    {
        // 현재 체력을 damage만큼 감소
        currentHP -= damage;
        //audioSource.Play();

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        //체력 0이하 = 적 사망
        if (currentHP <= 0)
        {
            GetComponent<Enemy>().Ondie();
            if (Meatlevel >= 1)
            {
                spawnMeatRandom = Random.Range(0, 100);
                if (spawnMeatRandom <= 5)
                {
                    Instantiate(Meatprefab, transform.position, Quaternion.identity);
                }
            }
            //GetComponent<PlayerEXP>().PlusExp(exp);
        }
    }
    private IEnumerator HitColorAnimation()
    {
        //적 색상을 빨간색으로 바꿈
        // 여기에 히트 애니메이션
        spriteRenderer.color = Color.red;
        // 0.1 초 히트 쿨타임
        yield return new WaitForSeconds(0.1f);
        //다시 하얀색으로 바꿈
        spriteRenderer.color = Color.white;
    }
}
