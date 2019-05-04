using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMonster : MonoBehaviour
{
    public int hp = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Damage()
    {
        if (hp <= 0)
            return;
        hp -= Random.Range(10, 20);
       
        if (hp <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
