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
}
