using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretView : MonoBehaviour
{

    public Slider Hp;
    public Text ScoreText;

    private ARGame ar;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        ar = ARGame.GetInstance();
        Hp.value  =  ARGame.sGameManage.GetPlayerData().GetHp();
        ScoreText.text = ARGame.sGameManage.GetPlayerData().GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Hp.value = ar.getGameManage().GetPlayerData().GetHp();
        ScoreText.text = ar.getGameManage().GetPlayerData().GetScore().ToString();
        
    }

    private void OnDestroy()
    {
        
    }
}
