using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private float maxHP = 10; //최대 체력
    private float currentHP; // 현재 체력
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private PlayerSliderHPSpawn playerSliderHPSpawn;
    Animator anim;

    // [SerializeField]
    // private GameObject Player;

    public float MaxHP => maxHP;   // maxHP변수에 접근 프로퍼티 (Get)
    public float CurrentHP => currentHP;  //currenHP변수에 접근 프로퍼티 (Get)

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
        // 현재 체력을 damage만큼 감소
        currentHP -= damage;
        audioSource.Play();

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        //체력 0이하 = 플레이어 사망
        if(currentHP <= 0)
        {
            anim.SetTrigger("Dead");
            Debug.Log("Player Hp : 0 ..Die");
            SceneManager.LoadScene(nextSceneName);
        }
    }
    private IEnumerator HitColorAnimation()
    {
        //플레이어 색상을 빨간색으로 바꿈
        spriteRenderer.color = Color.red;
        // 0.1 초 히트 쿨타임
        yield return new WaitForSeconds(0.1f);
        //다시 하얀색으로 바꿈
        spriteRenderer.color = Color.white;
    }
}
