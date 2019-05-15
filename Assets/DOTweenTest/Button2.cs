using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Button2 : MonoBehaviour {
    public RectTransform image1;
    private bool isIn = false;   //是否在屏幕内

    void Start ()
    {
        //接收生成的动画
                            //第一个参数：目标地点，就是要移动到哪个位置
                            //第二个参数：移动到那个位置需要的时间
        Tweener tweener = image1.DOLocalMove(new Vector3(0, 0, 0), 1);
        //设置自动销毁动画为false
        tweener.SetAutoKill(false);
        //暂停动画，不然会一开始就播放动画
        tweener.Pause();

    }
    
    public void TransformImage ()
    {
        if (isIn == false)
        {
            //向前播放动画，就是播放上面创建的动画
            image1.DOPlayForward();
            isIn = true;
        }
        else
        {
            //倒放动画
            image1.DOPlayBackwards();
            isIn = false;
        }
    }

}
