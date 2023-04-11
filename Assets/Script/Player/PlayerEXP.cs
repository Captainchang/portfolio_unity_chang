using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;


public class PlayerEXP : MonoBehaviour
{
    [SerializeField]
    private int[] MaxEXP = new int [30];
    public GameObject abilityUI;
    public GameObject ImageUI;
    private AudioSource levelupaudio;
    private int currentEXP = 0;
   // Weapon weapon;
    [SerializeField]
    private Button[] abilitybuttons= new Button[10];
    public int level = 0;
    public int[] MaxExp => MaxEXP;
    public float CurrentExp => currentEXP;

    private Slider slider;
    private void Awake()
    {
        abilityUI.SetActive(false);
        ImageUI.SetActive(false);
        slider = GetComponent<Slider>();
        levelupaudio= GetComponent<AudioSource>();
       // weapon= GetComponent<Weapon>();
        MaxExp[0] = currentEXP;

        int j = 10;
        for (int level = 0; level < MaxEXP.Length; level++)
        {
            MaxEXP[level] += j;
            j += 10;
        }
        float fillAmount = (float)currentEXP / MaxEXP[level];
        slider.value = fillAmount;
        buttonFalse();
    }
    public void buttonFalse()
    {
        for (int i = 0; i < abilitybuttons.Length; i++)
        {
            abilitybuttons[i].gameObject.SetActive(false);
        }
    }
    public void UIfalse()
    {
        abilityUI.SetActive(false);
        
    }
    public void PlusExp(int exp)
    {
        if (Weapon.explosionLevel >= 3)
        {
            abilitybuttons[0] = abilitybuttons[4];
        }
        if (Weapon.RanageWeaponLevel >= 4)
        {
            abilitybuttons[1] = abilitybuttons[5];
        }
        if (EnemyHP.Meatlevel >= 1)
        {
            abilitybuttons[2] = abilitybuttons[6];
        }
        if(Weapon.attackRateLevel>= 4)
        {
            abilitybuttons[3] = abilitybuttons[7];
        }
        int buttonindex1 = Random.Range(0,4);
        int buttonindex2 = Random.Range(0,4);
        int buttonindex3 = Random.Range(0,4);

        while (buttonindex1 == buttonindex2)
        {
           buttonindex2 = Random.Range(0, 4);
        }
        while (buttonindex3 == buttonindex1 || buttonindex3 == buttonindex2)
        {
            buttonindex3 = Random.Range(0, 4);
        }
        currentEXP += exp;

        // 레벨 업 처리
        if (currentEXP >= MaxEXP[level])
        {
            levelupaudio.Play();
            currentEXP -= MaxEXP[level];
            level++;
            abilityUI.SetActive(true);
            ImageUI.SetActive(true);
            Time.timeScale = 0f;

            //abilitybuttons[buttonindex1].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(100,100,0));
            abilitybuttons[buttonindex1].transform.position = new Vector3(300,300,0);
            abilitybuttons[buttonindex1].gameObject.SetActive(true);
            
            abilitybuttons[buttonindex2].transform.position = new Vector3(550,300,0);
            abilitybuttons[buttonindex2].gameObject.SetActive(true);

            abilitybuttons[buttonindex3].transform.position = new Vector3(800,300,0);
            abilitybuttons[buttonindex3].gameObject.SetActive(true);
      
        }
        //buttonFalse();
        // 슬라이더 업데이트
        float fillAmount = (float)currentEXP / MaxEXP[level];
        slider.value = fillAmount;
    }
}
