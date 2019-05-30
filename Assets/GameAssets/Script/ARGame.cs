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

    public GameObject TurretGo;
    public Text ScoreText;
    public Text ScoreNum;
    private bool con  = false;
    private static ARGame _instance;

    public static ARGame GetInstance()
    {
        if (_instance == null)
            {
              _instance = GameObject.FindObjectOfType<ARGame>();
            }
            return _instance;
    }
    private void Awake()
    {
        sGameManage = new GameManage();
        StartBtn.onClick.AddListener(delegate ()
        {
            OnClick(StartBtn.gameObject);
        });
    }

    public  GameManage getGameManage()
    {
        return sGameManage;
    }
    private void OnClick(GameObject go)
    {
        if (go == StartBtn.gameObject)
        {
            sGameManage.StartDetectedPlane();
            StartBtn.gameObject.SetActive(false);
            ScoreText.gameObject.SetActive(false);
        }
    }

    void Start()
    {
        ScoreText.text = "Hello AR";
        ScoreNum.gameObject.SetActive(false);
    }

    void Update()
    {
        if(sGameManage.GetIsStartGame())
        {
            TurretView.SetActive(true);
            TurretGo.SetActive(true);
        }
    }

    public void EndGame()
    {
        sGameManage.EndGame();
        ScoreText.gameObject.SetActive(true);
        ScoreNum.gameObject.SetActive(true);
        ScoreNum.text = sGameManage.GetPlayerData().GetScore().ToString();
        ScoreText.text = "SCore";
        StartBtn.gameObject.SetActive(true);
        TurretView.SetActive(false);
        TurretGo.SetActive(false);
    }

    public  void StartGame()
    {
        sGameManage.StartGame();
    }
}
