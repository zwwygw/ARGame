using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARGame : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManage sGameManage;
    public Button StartBtn;
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

    // Update is called once per frame
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
    }

    void StartGame()
    {
        sGameManage.StartGame();
        StartBtn.gameObject.SetActive(false);
    }
}
