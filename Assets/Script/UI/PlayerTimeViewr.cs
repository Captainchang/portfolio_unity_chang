using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTimeViewr : MonoBehaviour
{
    private TextMeshProUGUI textTime;
    public float maintime = 0f;
    private void Awake()
    {
        textTime = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        maintime = Time.time;
        //text UI�� ���� ���� ������ ������Ʈ
        textTime.text = "Time " + maintime;
    }
}
