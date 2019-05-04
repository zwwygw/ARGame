using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class MonsterContrller : MonoBehaviour
{
    Animation _monsterAnim;
    private float runSpeed = 0.5f;
    private void Start()
    {
        _monsterAnim = GetComponent<Animation>();

    
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
            int dirMove = random.Next(1, 6);
            if(dirMove == 1)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * runSpeed);//向前移动
            }
            else if(dirMove == 2)
            {
                transform.Translate(Vector3.left * Time.deltaTime * runSpeed);//向前移动
            }
            else if(dirMove == 3)
            {
                transform.Translate(Vector3.up * Time.deltaTime * runSpeed);//向前移动
            }
            else if(dirMove == 4)
            {
                transform.Translate(Vector3.right * Time.deltaTime * runSpeed);//向前移动
            }
            else if (dirMove == 5)
            {
                transform.Translate(Vector3.back * Time.deltaTime * runSpeed);//向前移动
            }
            else if (dirMove == 6)
            {
                transform.Translate(Vector3.down * Time.deltaTime * runSpeed);//向前移动
            }

        }
    }
}
