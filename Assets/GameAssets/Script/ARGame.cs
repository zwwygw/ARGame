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
        StartBtn.gameObject.SetActive(true);
        TurretView.SetActive(false);
    }

    void StartGame()
    {
        sGameManage.StartGame();
        StartBtn.gameObject.SetActive(false);
        TurretView.SetActive(true);
    }
}
