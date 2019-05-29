using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlatformController : MonoBehaviour
{
    private int numMonster;
    public GameObject Monster;
    public GameObject MonsterParent;
    private const float k_ModelRotation = 180.0f;
    // Start is called before the first frame update
    private bool isInitMonster = false;
    private ARGame ar;
    void Start()
    {
        isInitMonster = true;
        ar = ARGame.GetInstance();
        ar.getGameManage().InitNumMonster();
        numMonster = ar.getGameManage().GetNumMonster();
        getMonsters();
        Debug.Log(ar.getGameManage().GetIsStartGame());
    }

    // Update is called once per frame
    void Update()
    {
        if (!ar.getGameManage().GetIsStartGame())
        {
            GameObject.Destroy(this.gameObject);
            return;
        }
        int currMonsterNum = ar.getGameManage().GetNumMonster();
        if (ar.getGameManage().GetIsStartGame() && (currMonsterNum <= 0))
        {
            ar = ARGame.GetInstance();
            ar.getGameManage().InitNumMonster();
            isInitMonster = true;
            numMonster = ar.getGameManage().GetNumMonster();
            getMonsters();
        }
    }

    private void getMonsters()
    {
        if(!isInitMonster)
        {
            return;
        }else{
            Invoke("initMonster",0.1f);           
        }
    }

    private void initMonster()
    {
        var monsterGO = Instantiate(Monster,MonsterParent.transform.position,MonsterParent.transform.rotation);
        monsterGO.transform.parent = MonsterParent.transform;
        numMonster --;
        if (numMonster <= 0)
        {
            isInitMonster = false;
        }
         getMonsters(); 
    }
}
