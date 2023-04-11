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
        //score 값이 음수X
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
        //이동 방향 설정
        //inputVec.x = joy.Horizontal;
        inputVec.x = Input.GetAxisRaw("Horizontal");
       // inputVec.y = joy.Vertical;
        inputVec.y = Input.GetAxisRaw("Vertical");


        movement2D.MoveTo(new Vector3(inputVec.x, inputVec.y, 0));

        if (inputVec.x != 0)
        {
            //좌우 캐릭터가 보는 방향으로.
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

        // 플레이어 캐릭터가 화면 범위 바깥으로 나가지 못하도록 함
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,stagedata.Limitmin.x,stagedata.Limitmax.x),
                                         Mathf.Clamp(transform.position.y,stagedata.Limitmin.y,stagedata.Limitmax.y));
    }
}
