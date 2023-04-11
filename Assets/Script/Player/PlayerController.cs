using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Stagedata stagedata;
   // [SerializeField]
   // private KeyCode KeyAttack = KeyCode.Space;
    private Movement2D movement2D;
    private Weapon weapon;
    private SpriteRenderer Spriter;
    public Vector2 inputVec;
    public VariableJoystick joy;
    [SerializeField]
    private float fireRate = 0.5f;
    private float nextFire = 0.0f;
    Animator anim;

    private int score;
    private int exp;
    public int Score
    {
        //score ���� ����X
        set => score = Mathf.Max(0, value);
        get => score;
    }
   public int EXP
    { 
       set => exp = Mathf.Max(0, value);
       get => exp;
    }
    

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        weapon= GetComponent<Weapon>();
        Spriter = GetComponent<SpriteRenderer>();
        anim= GetComponent<Animator>();
    }
    private void Update()
    {
        //�̵� ���� ����
        //inputVec.x = joy.Horizontal;
        inputVec.x = Input.GetAxisRaw("Horizontal");
       // inputVec.y = joy.Vertical;
        inputVec.y = Input.GetAxisRaw("Vertical");


        movement2D.MoveTo(new Vector3(inputVec.x, inputVec.y, 0));

        if (inputVec.x != 0)
        {
            //�¿� ĳ���Ͱ� ���� ��������.
            Spriter.flipX = inputVec.x < 0;
        }
       if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            weapon.StartFiring();
            weapon.StopFiring();
        }
        /*
        else if (Input.GetKeyUp(KeyAttack))
         {
             weapon.StopFiring();
         }
        */
    }
   
    private void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        // �÷��̾� ĳ���Ͱ� ȭ�� ���� �ٱ����� ������ ���ϵ��� ��
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,stagedata.Limitmin.x,stagedata.Limitmax.x),
                                         Mathf.Clamp(transform.position.y,stagedata.Limitmin.y,stagedata.Limitmax.y));
    }
}
