using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    EnemySpawner enemySpawner;
    PlayerTimeViewr playerTimeViewr;
    private void Awake()
    {
        enemySpawner= GetComponent<EnemySpawner>();
        playerTimeViewr = GetComponent<PlayerTimeViewr>();
    }
    public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        enemySpawner.gameTime = 0f;
        playerTimeViewr.maintime= 0f;

    }
}
