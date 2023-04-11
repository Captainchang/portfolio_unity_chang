using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerSocreViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerController PlayerController;
    private TextMeshProUGUI textScore;

    private void Awake()
    {
        textScore = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        //text UI에 현재 점수 정보를 업데이트
        textScore.text = "Score " + PlayerController.Score;
    }
}
