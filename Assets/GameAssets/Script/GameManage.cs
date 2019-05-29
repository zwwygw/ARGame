using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManage
{
    private bool isStartGame;
    private bool isDetecedPlane;
    private static PlayerData playerData;
    private static MonsterData monsterData;
    private static TurretData turretData;

    private int numMonster;
    private static GameManage _sGameManage = null; 
    public GameManage()
    {
        // _sGameManage = new GameManage();
        isStartGame = false;
        playerData  = new PlayerData();
        monsterData = new MonsterData();
        turretData  = new TurretData();
    }

     public  GameManage getInstance() {  
        return _sGameManage; 
    }
    public void StartDetectedPlane()
    {
        this.isDetecedPlane = true;
    }

    public void StartGame()
    {
        this.isDetecedPlane = false;
        this.isStartGame = true;
        initGameData();
    }

    private void initGameData()
    {
        playerData.initPlayerData();
        monsterData.initMonsterData();
        turretData.initTurretData();
    }

    public void EndGame()
    {
        this.isStartGame = false;
    }

    public bool getStartDectedPlane()
    {
        return this.isDetecedPlane;
    }

    public PlayerData GetPlayerData()
    {
        return playerData;
    }

    public MonsterData GetMonsterData()
    {
        return monsterData;
    }

    public TurretData GetTurretData()
    {
        return turretData;
    }

    public bool GetIsStartGame()
    {
        return this.isStartGame;
    }

    public void SetIsStartGame(bool status)
    {
        this.isStartGame = status;
    }

    public void InitNumMonster()
    {
        System.Random random = new System.Random((int)DateTime.Now.Ticks);
        this.numMonster = random.Next(10, 15);
    }

    public void SetNumMonster()
    {
        this.numMonster --;
    }
    public int GetNumMonster()
    {
        return this.numMonster;
    }
    ~GameManage()
    {

    }
}
