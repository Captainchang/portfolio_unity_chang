using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSliderHPSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyHPSliderPrefab; // Slider UI 프리팹
    [SerializeField]
    private Transform canvasTransform; // UI를 표현하는 canvas 오브젝트의 Transform
    public void SpawnEnemyHPSlider(GameObject Player)
    {
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);

        sliderClone.transform.SetParent(canvasTransform);

        sliderClone.transform.localScale = Vector3.one;

        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(Player.transform);
        
    }
}
