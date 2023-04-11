using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private float maxHP = 10; //�ִ� ü��
    private float currentHP; // ���� ü��
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private PlayerSliderHPSpawn playerSliderHPSpawn;
    Animator anim;

    // [SerializeField]
    // private GameObject Player;

    public float MaxHP => maxHP;   // maxHP������ ���� ������Ƽ (Get)
    public float CurrentHP => currentHP;  //currenHP������ ���� ������Ƽ (Get)

    private void Awake()
    {
        currentHP = maxHP;

        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        anim= GetComponent<Animator>();
        //GetComponent<PlayerSliderHPSpawn>().SpawnEnemyHPSlider(Player);
    }
    public void EatMeat(float heal)
    {
        if(maxHP != currentHP) 
        {
            currentHP += heal;
        }
        Debug.Log("Player HP++");
    }
    public void MaxHpplus()
    {
        maxHP += 1;
    }
    public void TakeDamage(float damage)
    {
        // ���� ü���� damage��ŭ ����
        currentHP -= damage;
        audioSource.Play();

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        //ü�� 0���� = �÷��̾� ���
        if(currentHP <= 0)
        {
            anim.SetTrigger("Dead");
            Debug.Log("Player Hp : 0 ..Die");
            SceneManager.LoadScene(nextSceneName);
        }
    }
    private IEnumerator HitColorAnimation()
    {
        //�÷��̾� ������ ���������� �ٲ�
        spriteRenderer.color = Color.red;
        // 0.1 �� ��Ʈ ��Ÿ��
        yield return new WaitForSeconds(0.1f);
        //�ٽ� �Ͼ������ �ٲ�
        spriteRenderer.color = Color.white;
    }
}
