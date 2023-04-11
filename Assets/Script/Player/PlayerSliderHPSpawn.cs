using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSliderHPSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyHPSliderPrefab; // Slider UI ������
    [SerializeField]
    private Transform canvasTransform; // UI�� ǥ���ϴ� canvas ������Ʈ�� Transform
    public void SpawnEnemyHPSlider(GameObject Player)
    {
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);

        sliderClone.transform.SetParent(canvasTransform);

        sliderClone.transform.localScale = Vector3.one;

        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(Player.transform);
        
    }
}
