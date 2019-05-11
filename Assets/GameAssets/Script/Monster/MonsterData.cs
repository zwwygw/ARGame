using System;
using System.Collections;

public class MonsterData
{
    //血量
    private int hp;
    //伤害
    private int hurt;
    //
    enum Monster1 {hp=10,hurt=10}
    enum Monster2 {hp = 20, hurt = 10}

    public MonsterData()
    {
        this.hp = (int)Monster1.hp;
        this.hurt = (int)Monster1.hurt;
    }

    public int GetHp()
    {
        return this.hp;
    }

    public int GetHurt()
    {
        return this.hurt;
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
}
