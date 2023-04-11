using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab; // 공격할 때 생성되는 발사체 프리팹
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private GameObject RnagePrefab;
    [SerializeField]
    private GameObject SheepPrefab;
    private float attackRate = 1.0f; // 공격 속도
    public static int attackRateLevel = 0; // 공격 속도 아이템  레벨
    [SerializeField]
    private float explosionAttackRate = 0.0f; // 폭탄 공속
    [SerializeField]
    bool explosionhave = true;
    public static int explosionLevel = 0; // 폭탄 아이템의 레벨
    bool Rangehave = true;
    public static int RanageWeaponLevel = 0; // 근접무기 아이템의 레벨
    private Movement2D movement2D;
    private PlayerController playerController;
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit2D[] targets;
    public Transform nearstTarget;
    PlayerHP playerHP;
    int heal = 1;
    [SerializeField]
    GameObject[] RangeWp;
    GameObject cloneRange = null;
 
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        for(int i =0; i < RangeWp.Length; i++)
        {
            RangeWp[i].SetActive(false);
        }
    }
    public void StartFiring()
    {
        StartCoroutine("TryAttack");
    }
    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }
    public void LevelUpExplosion()
    {
        if (explosionLevel <= 3)
            explosionLevel++;
        Time.timeScale = 1f;
    }
    public void LevelpUpRange()
    {
        //GameObject cloneRange = null;
        if (RanageWeaponLevel < 4)
        {
            RanageWeaponLevel++;
            switch (RanageWeaponLevel)
            {

                case 1:
                    //cloneRange = Instantiate(RnagePrefab, RangeWp.transform.position + new Vector3(0,1,0) * 2.6f, Quaternion.identity);
                    //cloneRange.transform.parent = GameObject.FindGameObjectWithTag("Weapon").transform;
                    RangeWp[0].SetActive(true);
                    break;
                case 2:
                    //cloneRange = Instantiate(RnagePrefab, RangeWp.transform.position + new Vector3(0, -1, 0) * 2.6f, Quaternion.identity);
                    //cloneRange.transform.parent = GameObject.FindGameObjectWithTag("Weapon").transform;
                    RangeWp[1].SetActive(true);
                    break;
                case 3:
                    //cloneRange = Instantiate(RnagePrefab, RangeWp.transform.position + new Vector3(-1, 0, 0) * 2.6f, Quaternion.identity);
                    //cloneRange.transform.parent = GameObject.FindGameObjectWithTag("Weapon").transform;
                    RangeWp[2].SetActive(true);
                    break;
                case 4:
                    // cloneRange = Instantiate(RnagePrefab, RangeWp.transform.position + new Vector3(1, 0, 0) * 2.6f, Quaternion.identity);
                    //cloneRange.transform.parent = GameObject.FindGameObjectWithTag("Weapon").transform;
                    RangeWp[3].SetActive(true);
                    break;
            }
            Time.timeScale = 1f;
        }
    }
    public void LevelUpPosion()
    {
        Time.timeScale = 1f;
    }
    public void LevelUpAttackrate()
    {
        if (attackRateLevel <= 4)
        {
            attackRateLevel++;
            attackRate -= 0.1f;
            Time.timeScale = 1f;
        }
    }
    public void LevelUpMeat()
    {
        if(EnemyHP.Meatlevel < 1)
        EnemyHP.Meatlevel++;
        Time.timeScale = 1f;
    }
    public void LevelUpMovement()
    {
        Movement2D.moveSpeed += 1f;
        Time.timeScale = 1f;
    }
    private void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero,0,targetLayer);
        nearstTarget = GetNearest();
        if (explosionAttackRate <= 3.0f)
        {
            explosionAttackRate = explosionAttackRate + Time.deltaTime;
        }
    }
    Transform GetNearest()
    {
        Transform result = null;
        float diff = 100;

        foreach(RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos);

            if (curDiff < diff)
            {
                diff = curDiff;
                result = target.transform;
            }
        }
        return result;
    }
    public void SheepWeapon()
    {
      //  GameObject cloneSheep = null;
        
       // Vector3 near = nearstTarget.position;
        //Vector3 dir = near - transform.position;
        //dir = dir.normalized;
       
     //   cloneSheep = Instantiate(SheepPrefab, transform.position, Quaternion.identity);

      //  cloneSheep.GetComponent<Movement2D>().MoveTo(dir);
      //  Time.timeScale = 1f;
    }
    private IEnumerator TryAttack()
    {
        //float px;
      // float py;
        GameObject cloneProjectile = null;
        GameObject cloneKnife = null;

        // px = playerController.x;
        // py = playerController.y;
        Vector3 near = nearstTarget.position;
        Vector3 dir = near - transform.position;
        dir = dir.normalized;
        
        while (true)
        {
            //발사체 오브젝트 생성
            cloneProjectile=  Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            if (dir.x <= 0)
            {
                cloneProjectile.GetComponent<SpriteRenderer>().flipX = dir.x < 0;
            }
            cloneProjectile.GetComponent<Movement2D>().MoveTo(dir);

            if (explosionhave == true && explosionAttackRate >= 3.0f)
            {
                switch (explosionLevel)
                {
                    case 1:
                        cloneKnife = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                        cloneKnife.GetComponent<Movement2D>().MoveTo(dir);
                        break;
                    case 2:
                        cloneKnife = Instantiate(explosionPrefab, transform.position + Vector3.left * 2f, Quaternion.identity);
                        cloneKnife.GetComponent<Movement2D>().MoveTo(dir);
                        cloneKnife = Instantiate(explosionPrefab, transform.position+ Vector3.right * 2f, Quaternion.identity);
                        cloneKnife.GetComponent<Movement2D>().MoveTo(dir);   
                        break; 

                    case 3:
                        cloneKnife = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                        cloneKnife.GetComponent<Movement2D>().MoveTo(dir); 
                        cloneKnife = Instantiate(explosionPrefab, transform.position + Vector3.left * 2f, Quaternion.identity);
                        cloneKnife.GetComponent<Movement2D>().MoveTo(dir);
                        cloneKnife = Instantiate(explosionPrefab, transform.position + Vector3.right * 2f, Quaternion.identity);
                        cloneKnife.GetComponent<Movement2D>().MoveTo(dir);
                        break;
                 }

                explosionAttackRate = 0.0f;
            } 
            //Attack Rate 만큼 대기하기
            yield return new WaitForSeconds(attackRate);
        }
    }
}
