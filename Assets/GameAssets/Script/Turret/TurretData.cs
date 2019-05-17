using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretData
{
    private int hurt;

    public TurretData()
    {
        this.hurt = 10;
    }

    public void initTurretData()
    {
        this.hurt = 10;

    }

    public int getHurt()
    {
        return this.hurt;
    }
}
