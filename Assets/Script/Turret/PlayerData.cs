using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private int hp;
    private string name;
    private int score;

    public PlayerData()
    {
            
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
