using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;

public class MonsterContrller : MonoBehaviour
{
    Animation _monsterAnim;
    private float runSpeed = 3f;
    private MonsterData monster;
    private ARGame ar;
    private Rigidbody mRig;
    private Transform mTran;
    private GameObject player;
    private Vector3 currPos ;
    private bool isAttack = false;
    // private System.Random random = new System.Random((int)DateTime.Now.Ticks);
    private void Start()
    {
        GameObject root = GameObject.Find("ARCore");
        player = root.transform.Find("FPCamera/Turret").gameObject;
        // Debug.Log(player);
         mRig = GetComponent<Rigidbody>();
         mTran = GetComponent<Transform>();
        ar = ARGame.GetInstance();
        _monsterAnim = GetComponent<Animation>();
        monster = new MonsterData();
        System.Random random = new System.Random();
        int randomX = random.Next(0,5)-2;
        int randomY = random.Next(0,5)-2;
        int randomZ = random.Next(0,5)-2;
        Vector3 initPos = new Vector3(randomX,randomY,randomZ);
        gameObject.transform.DOLocalMove(initPos,1);
    }
    void Update()
    {
        if (_monsterAnim != null)
        {
            _monsterAnim.Play("idle");
            monsterMove();
            if(!ar.getGameManage().GetIsStartGame())
            {
                GameObject.Destroy(this.gameObject); 
            }
        }
    }
    void FixedUpdate()
    {
        // if (_monsterAnim != null)
        // {
        //     _monsterAnim.Play("idle");
        // //    monsterMove();
        // Invoke("monsterMove",2);
        // }
    }

    private void moveByTween()
    {

    }
//             Vector3 velocity = Vector3.zero;//速度
//  float speed = 5;
    private void monsterMove(){
   
            System.Random random = new System.Random();
            // float direction = (float)random.Next(0, 360);//在0--360之间随机生成一个单精度小数)
            // Vector3 target = transform.position + Quaternion.Euler(0, direction, 0) * Vector3.right * 10;//随机指定目标
            // Vector3 direct = target - transform.position;
            // direct.y = 0;//防止y方向移动
            //  if (direct.sqrMagnitude > 1)
            // {
            //     transform.rotation = Quaternion.LookRotation(direct);//改变朝向
            // }

            // transform.rotation = Quaternion.LookRotation(direction);//旋转指定度数
            int dirMove = random.Next(0, 11);
            // if(dirMove < 7)
            // {
            //     monsterAttack();
            // }
        //     velocity -= GetComponent<Rigidbody>().velocity;
        // velocity.y = 0;

        // //速度过大时减速
        // if (velocity.sqrMagnitude > speed * speed) 
        //     velocity = velocity.normalized * speed;

        // GetComponent<Rigidbody>().AddForce(velocity, ForceMode.VelocityChange);
        // velocity = Vector3.zero;

            runSpeed = 5;
            // Vector3 currPos = gameObject.transform.localPosition;
            // int randomX = random.Next(0,5)-2;
            // int randomY = random.Next(0,5)-2;
            // int randomZ = random.Next(0,5)-2;
            // Vector3 targetPos = currPos + new Vector3(randomX,randomY,randomZ);  
            // Debug.Log(targetPos);  
            // gameObject.transform.DOLocalMove(targetPos,3);
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
            }if(dirMove > 6 && !isAttack){
                currPos = gameObject.transform.position;
                monsterAttack();
            }
    }

    public float smoothTime = 10F;
    private Vector3 velocity = Vector3.zero;
    private void monsterAttack()
    {
        isAttack = true;
        //  Vector3 currPos = gameObject.transform.position;
         Vector3 targetPos = player.transform.position;
         transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        //  mRig.MovePosition(targetPos*runSpeed);
        //  gameObject.transform.DOMove(targetPos,2);
         _monsterAnim.Play("attack");    
         transform.position = Vector3.SmoothDamp(targetPos, currPos, ref velocity, smoothTime);  
             //mRig.MovePosition(currPos*runSpeed);
        //  gameObject.transform.DOMove(currPos,3);
    }

    void Damage()
    {
        int hp = monster.GetHp();
        if (hp <= 0)
            return;
        hp -= UnityEngine.Random.Range(10, 20);
        monster.SetHp(hp);
        transform.DOShakePosition(1, new Vector3(0, 1, 0));
        if (hp <= 0)
        {
            ar.getGameManage().GetPlayerData().SetScore(); 
            ar.getGameManage().SetNumMonster();  
            Debug.Log( ar.getGameManage().GetNumMonster());       
            GameObject.Destroy(this.gameObject);           
        }
    }

    public static void Shock()
    {
        Handheld.Vibrate();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            Shock();
            other.collider.SendMessage("Damage");
        }
    }
}
