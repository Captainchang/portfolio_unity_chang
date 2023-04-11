using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Stagedata stagedata; //�� ���������� �������� ũ��
    /*[SerializeField]
    private GameObject enemyPrefab; // �� ������
    [SerializeField]
    private GameObject enemyPrefab2; // ��2 ������
    */
    [SerializeField]
    private GameObject enemyHPSliderPrefab; //�� ü���� ��Ÿ���� Slider UI ������
    [SerializeField]
    private Transform canvasTransform;  //UI�� ǥ���ϴ� Canvas ������Ʈ�� Transform
    [SerializeField]
    private float spawnTime = 0f; //�����ð� ����
    private Movement2D movement;
    [SerializeField]
    private GameObject[] enemyRandom;
    public float gameTime;
    private float levelgameTime = 1 * 10f; // ���� ���� �ð�

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
            // �������� �����;ȿ��� x,y�� ����
            float positionX = Random.Range(stagedata.Limitmin.x, stagedata.Limitmax.x);
            float positionY = Random.Range(stagedata.Limitmin.y, stagedata.Limitmax.y);
            //�� ĳ���� ����
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
        //�� ü���� ��Ÿ���� Sldier UI ����.
        GameObject sldierclone = Instantiate(enemyHPSliderPrefab);

        sldierclone.transform.SetParent(canvasTransform);

        sldierclone.transform.localScale= Vector3.one;

        sldierclone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);
    }
}
