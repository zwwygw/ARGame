using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretController : MonoBehaviour
{
    public Button FireBtn;
    public Transform firePos;
    public float speed = 15f;
    public GameObject shelPref;
    private PlayerData playerData;

    private ARGame ar;
    private void Awake()
    {
        FireBtn.onClick.AddListener(delegate ()
        {
            OnFireBtnClick(FireBtn.gameObject);
        });
        
    }
    // Start is called before the first frame update
    void Start()
    {
        ar = ARGame.GetInstance();
        playerData = new PlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //UGUI按钮点击触发
    private void OnFireBtnClick(GameObject go)
    {
        if (go == FireBtn.gameObject)
        {
            GameObject shell = GameObject.Instantiate(shelPref, firePos.position, firePos.rotation) as GameObject;
            shell.transform.parent = firePos;
            shell.transform.localScale = new Vector3(1,1,1);
            shell.GetComponent<Rigidbody>().velocity = shell.transform.forward * speed;
            GameObject.Destroy(shell, 2);
        }
    }

    private void Damage()
    {
        int hp = ARGame.sGameManage.GetPlayerData().GetHp();
        if (hp <= 0)
            return;
        hp -= Random.Range(1, 2);
        ARGame.sGameManage.GetPlayerData().SetHp(hp);
        if (hp <= 0)
        {
           ar.EndGame();
        }
    }

    private void OnDestroy()
    {
        
    }
}
