using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Shake : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //第一个参数：震动时长
        //第二个：震动的轴
        //震动强度默认是1   0~1（没写出来）
        transform.DOShakePosition(1, new Vector3(1, 1, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
