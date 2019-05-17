using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARGame : MonoBehaviour
{
    public static GameManage sGameManage;
    public Button StartBtn;
    public GameObject TurretView;
    public Text ScoreText;
    private void Awake()
    {
        sGameManage = new GameManage();
        StartBtn.onClick.AddListener(delegate ()
        {
            OnClick(StartBtn.gameObject);
        });
    }

    private void OnClick(GameObject go)
    {
        if (go == StartBtn.gameObject)
        {
            StartGame();
        }
    }

    void Start()
    {
        ScoreText.text = "欢迎游戏";
    }

    void Update()
    {
        if (!sGameManage.GetIsStartGame())
        {
            EndGame();
        }
    }

    void EndGame()
    {
        sGameManage.EndGame();
        ScoreText.gameObject.SetActive(true);
        ScoreText.text = sGameManage.GetPlayerData().GetScore().ToString();
        StartBtn.gameObject.SetActive(true);
        TurretView.SetActive(false);
    }

    void StartGame()
    {
        sGameManage.StartGame();
        StartBtn.gameObject.SetActive(false);
        ScoreText.gameObject.SetActive(false);
        TurretView.SetActive(true);
    }
}
