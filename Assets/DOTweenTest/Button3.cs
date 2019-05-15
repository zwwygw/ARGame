using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Button3 : MonoBehaviour {
    public Transform cube2;

    public void TransCube2 ()
    {
        //移动cube1的x轴，从当前位置移动到 5，需要的时间为 1秒
        cube2.DOMoveX(5, 4).From(true);
    }
}
