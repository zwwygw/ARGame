using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterContrller : MonoBehaviour
{
    Animation _monsterAnim;
    private float runSpeed = 1f;
    private MonsterData monster;
    private void Start()
    {
        _monsterAnim = GetComponent<Animation>();
        monster = new MonsterData();    
    }
    void Update()
    {
       
    }
    void FixedUpdate()
    {
        if (_monsterAnim != null)
        {
            _monsterAnim.Play("idle");
            System.Random random = new System.Random((int)DateTime.Now.Ticks);
            float direction = (float)random.Next(0, 360);//在0--360之间随机生成一个单精度小数)
         //   transform.rotation = Quaternion.Euler(0, direction, 0);//旋转指定度数
            int dirMove = random.Next(0, 7);
            runSpeed = (float)random.Next(0, 2);
                
            if(dirMove == 1)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * runSpeed);//向前移动
            }
            else if(dirMove == 2)
            {
                transform.Translate(Vector3.left * Time.deltaTime * runSpeed);//向左移动
            }
            else if(dirMove == 3)
            {
                transform.Translate(Vector3.up * Time.deltaTime * runSpeed);//向上移动
            }
            else if(dirMove == 4)
            {
                transform.Translate(Vector3.right * Time.deltaTime * runSpeed);//向右移动
            }
            else if (dirMove == 5)
            {
                transform.Translate(Vector3.back * Time.deltaTime * runSpeed);//向后移动
            }
            else if (dirMove == 6)
            {
                transform.Translate(Vector3.down * Time.deltaTime * runSpeed);//向下移动
            }
        }
    }
    void Damage()
    {
        int hp = monster.getHp();
        if (hp <= 0)
            return;
        hp -= UnityEngine.Random.Range(10, 20);

        if (hp <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
