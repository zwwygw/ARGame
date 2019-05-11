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
    private void Awake()
    {
        FireBtn.onClick.AddListener(delegate ()
        {
            OnClick(FireBtn.gameObject);
        });
        
    }
    // Start is called before the first frame update
    void Start()
    {
        playerData = new PlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //UGUI按钮点击触发
    private void OnClick(GameObject go)
    {
        if (go == FireBtn.gameObject)
        {
            GameObject shell = GameObject.Instantiate(shelPref, firePos.position, firePos.rotation) as GameObject;
            shell.GetComponent<Rigidbody>().velocity = shell.transform.forward * speed;
            GameObject.Destroy(shell, 2);
        }
    }

    void Damage()
    {
        int hp = playerData.GetHp();
        if (hp <= 0)
            return;
        hp -= Random.Range(10, 20);
        playerData.SetHp(hp);
        if (hp <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        
    }
}
