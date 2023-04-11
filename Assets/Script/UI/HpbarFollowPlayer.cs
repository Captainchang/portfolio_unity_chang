using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpbarFollowPlayer : MonoBehaviour
{
    RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    private void FixedUpdate()
    {
        //�÷��̾� ��ġ find �Լ��� ã�� 
        GameObject Player = GameObject.Find("Player");
        Vector3 Playerposition = Player.transform.position - new Vector3(0,1.7f,0);
        rect.position = Camera.main.WorldToScreenPoint(Playerposition);
    }
}
