using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {

    [SerializeField]
    private Animator anim;
    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        //销毁动画残留副本
        AnimatorClipInfo[] animInfos = anim.GetCurrentAnimatorClipInfo(0);

        Destroy(this.gameObject, animInfos[0].clip.length);
    }
}
