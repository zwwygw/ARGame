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

    public int getHp()
    {
        return this.hp;
    }


    public int getHurt()
    {
        return this.hurt;
    }
}
