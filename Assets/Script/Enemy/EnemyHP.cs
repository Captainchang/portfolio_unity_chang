using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 3; //�ִ� ü��
    private float currentHP; // ���� ü��
    private int exp = 1;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private Enemy enemy;
    [SerializeField]
    GameObject Meatprefab;
    int spawnMeatRandom;
    public static int Meatlevel = 0;
    public float MaxHP => maxHP;   // maxHP������ ���� ������Ƽ (Get)
    public float CurrentHP => currentHP;  //currenHP������ ���� ������Ƽ (Get)

    private void Awake()
    {
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();      
    }
    public void EnemyTakeDamage(float damage)
    {
        // ���� ü���� damage��ŭ ����
        currentHP -= damage;
        //audioSource.Play();

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        //ü�� 0���� = �� ���
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
        //�� ������ ���������� �ٲ�
        // ���⿡ ��Ʈ �ִϸ��̼�
        spriteRenderer.color = Color.red;
        // 0.1 �� ��Ʈ ��Ÿ��
        yield return new WaitForSeconds(0.1f);
        //�ٽ� �Ͼ������ �ٲ�
        spriteRenderer.color = Color.white;
    }
}
