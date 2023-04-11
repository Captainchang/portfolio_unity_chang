using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private int scorePoint = 1; //�� óġ ����
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]    
    private PlayerEXP playerExp;
    private AudioSource audioSource;
    Rigidbody2D rigid;
   //private PlayerEXP playerEXP;
    private void Awake()
    {
        playerController= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerExp = GameObject.FindGameObjectWithTag("EXPUI").GetComponent<PlayerEXP>();
        audioSource= gameObject.AddComponent<AudioSource>();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //������ �ε��� ������Ʈ�� �±װ� "Player"�̸�
        if (collision.CompareTag("Player"))
        {
           collision.GetComponent<PlayerHP>().TakeDamage(damage);
           audioSource.Play();
           Destroy(gameObject);
        }
        //������ �ε��� ������Ʈ�� �±װ� "Bullet"�̸�
       // if (collision.CompareTag("Bullet"))
      //  {
      //      StopCoroutine("Knockback");
      //      StartCoroutine("Knockback");
      //  }
    }
  
    IEnumerator Knockback()
    {
        yield return null;
        Vector3 Pos = playerController.transform.position;
        Vector3 dirvec = transform.position - Pos;
        rigid.AddForce(dirvec.normalized ,ForceMode2D.Impulse);
        
    }
    public void Ondie()
    {
        playerController.Score += scorePoint;
        int exp = 1;

        if (playerExp != null)
        {
            playerExp.PlusExp(exp);
        }
       // audioSource.Play();
        Destroy(gameObject);
    }
}
