using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private int hp = 0;
    private string name = " ";
    private int score = 0;
    enum Player { hp = 100}

    public PlayerData()
    {
        this.hp = (int)Player.hp;
        this.score = 0;
    }

    public void initPlayerData()
    {
        this.hp = (int)Player.hp;
        this.score = 0;
    }


    public void SetScore(int score)
    {
        if(score < 0)
        {
            this.score = 0;
        }
        else
        {
            this.score = score;
        }
    }


    public void SetHp(int hp)
    {
        if (hp < 0)
        {
            this.hp = 0;
        }
        else
        {
            this.hp = hp;
        }
    }

    public int GetHp()
    {
        return this.hp;
    }

    public int GetScore()
    {
        return this.score;
    }

    public string GetName()
    {
        return this.name;
    }
}
