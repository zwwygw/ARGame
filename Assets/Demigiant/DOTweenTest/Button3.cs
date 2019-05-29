using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Button3 : MonoBehaviour {
    public Transform cube2;
    private bool isIn = false;   //是否在屏幕内
    public void TransCube2 ()
    {
        var seq = DOTween.Sequence();
        seq.Insert(0,cube2.DOMoveX(5, 1));
        seq.Insert(0, cube2.DOMoveY(5, 1));

    }
    private void kill(Sequence s)
    {
        s.Kill(false);
    }

}
