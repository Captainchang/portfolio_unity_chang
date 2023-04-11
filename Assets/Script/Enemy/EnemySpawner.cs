using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Stagedata stagedata; //적 생성을위한 스테이지 크기
    /*[SerializeField]
    private GameObject enemyPrefab; // 적 프리펩
    [SerializeField]
    private GameObject enemyPrefab2; // 적2 프리팹
    */
    [SerializeField]
    private GameObject enemyHPSliderPrefab; //적 체력을 나타내는 Slider UI 프리팹
    [SerializeField]
    private Transform canvasTransform;  //UI를 표현하는 Canvas 오브젝트의 Transform
    [SerializeField]
    private float spawnTime = 0f; //생성시간 조절
    private Movement2D movement;
    [SerializeField]
    private GameObject[] enemyRandom;
    public float gameTime;
    private float levelgameTime = 1 * 10f; // 레벨 스폰 시간

    PlayerController playerController;
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        StopCoroutine("SpawnEnemy");
        StartCoroutine("SpawnEnemy");
    }
    private void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime > levelgameTime)
        {
            gameTime = 0;
            if (spawnTime > 0.1f)
            {
                spawnTime = spawnTime - 0.1f;
            }
        }
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int index = Random.Range(0, enemyRandom.Length);
            int spawntrans = Random.Range(0, 3);
            GameObject enemy = enemyRandom[index];
            // 스테이지 데이터안에서 x,y값 랜덤
            float positionX = Random.Range(stagedata.Limitmin.x, stagedata.Limitmax.x);
            float positionY = Random.Range(stagedata.Limitmin.y, stagedata.Limitmax.y);
            //적 캐릭터 생성
            switch (spawntrans)
            {
            case 0:
                    Instantiate(enemy, new Vector3(positionX, stagedata.Limitmax.y + 1.0f, 0), Quaternion.identity);
                    Instantiate(enemy, new Vector3(positionX, stagedata.Limitmax.y + 1.0f, 0), Quaternion.identity);
                    //SpawnEnemyHPSldier(enemy);
                    break;
            case 1:
                    Instantiate(enemy, new Vector3(positionX, stagedata.Limitmin.y - 1.0f, 0), Quaternion.identity);
                    Instantiate(enemy, new Vector3(positionX, stagedata.Limitmin.y - 1.0f, 0), Quaternion.identity);
                    //SpawnEnemyHPSldier(enemy);
                    break;
            case 2:
                    Instantiate(enemy, new Vector3(stagedata.Limitmax.x + 1.0f, positionY, 0), Quaternion.identity);
                    Instantiate(enemy, new Vector3(stagedata.Limitmax.x + 1.0f, positionY, 0), Quaternion.identity);
                    //SpawnEnemyHPSldier(enemy);
                    break;
            case 3:
                    Instantiate(enemy, new Vector3(stagedata.Limitmin.x - 1.0f, positionY, 0), Quaternion.identity);
                    Instantiate(enemy, new Vector3(stagedata.Limitmin.x - 1.0f, positionY, 0), Quaternion.identity);
                    // SpawnEnemyHPSldier(enemy);
                    break;    
            }
          
            // GetComponent<Movement2D>().MoveToPlayer(transform);
            yield return new WaitForSeconds(spawnTime);
           
        }
    }

    private void SpawnEnemyHPSldier(GameObject enemy)
    {
        //적 체력을 나타내는 Sldier UI 생성.
        GameObject sldierclone = Instantiate(enemyHPSliderPrefab);

        sldierclone.transform.SetParent(canvasTransform);

        sldierclone.transform.localScale= Vector3.one;

        sldierclone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);
    }
}
