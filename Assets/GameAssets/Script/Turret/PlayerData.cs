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
    }

    public void SetScore(int score)
    {
        if(score < 0)
        {
            return;
        }
        else
        {
            this.score = score;
        }
    }

    public int getHp()
    {
        return this.hp;
    }

    public int getScore()
    {
        return this.score;
    }

    public string getName()
    {
        return this.name;
    }
}
