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
        // ��⿡ �ε��� ������Ʈ�� �±װ� "Player" �̸�
        if (collision.CompareTag("Player"))
        {
            //�÷��̾� hp ȸ��
            collision.GetComponent<PlayerHP>().EatMeat(heal);
            // ��� ����
            Destroy(gameObject);

            
        }
    }
}
