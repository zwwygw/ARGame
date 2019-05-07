using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage
{
    private bool isStartGame;
    private PlayerData playerData;
    private MonsterData monsterData;
    private TurretData turretData;

    public GameManage()
    {
        isStartGame = false;
        playerData  = new PlayerData();
        monsterData = new MonsterData();
        turretData  = new TurretData();
    }

    public void StartGame()
    {
        this.isStartGame = true;
    }

    public void EndGame()
    {

    }

    public PlayerData GetPlayerData()
    {
        return this.playerData;
    }

    public MonsterData GetMonsterData()
    {
        return this.monsterData;
    }

    public TurretData GetTurretData()
    {
        return this.turretData;
    }

    public bool GetIsStartGame()
    {
        return this.isStartGame;
    }

    public void SetIsStartGame(bool status)
    {
        this.isStartGame = status;
    }

    ~GameManage()
    {

    }
}
