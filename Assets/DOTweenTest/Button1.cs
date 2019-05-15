using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Button1 : MonoBehaviour {
    public Transform cubeTrans;   //得到cube的transform
    public Vector3 myValue = new Vector3(0, 0, 0);

	// Update is called once per frame
	void Update () {
        cubeTrans.position = myValue;
	}

   
    public void ControllerCube ()
    {
        //DOTween自带的方法：对变量做一个动画（通过插值的方式修改一个值得变化） 要使用 using DG.Tweening; 命名空间
        //第一个参数：使用了 C# 的Lambda语法，对 myValue 值进行修改，返回 myValue
        //第二个：也使用 Lambda 语法，把修改的值赋给 myValue，x是DOTween计算好的一个值
        //第三个：目标值，就是 myValue 最后要变化到的值
        //第四个：变化到目标值需要的时间
        DOTween.To(() => myValue, x => myValue = x, new Vector3(10, 10, 10), 2);
    }
}
