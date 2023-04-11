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
        //text UI�� ���� ���� ������ ������Ʈ
       // textspawn.text = "Enemy " + playerController.Spawncount;
    }

}
