using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawnViewer : MonoBehaviour
{
    EnemySpawner enemySpawner;
    PlayerController playerController;
    private TextMeshProUGUI textspawn;

    private void Awake()
    {
        playerController= GetComponent<PlayerController>(); 
        enemySpawner= GetComponent<EnemySpawner>();
        textspawn = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        //text UI에 현재 점수 정보를 업데이트
       // textspawn.text = "Enemy " + playerController.Spawncount;
    }

}
