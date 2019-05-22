using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniSpeed : MonoBehaviour
{
    Animator anim;
    AnimatorStateInfo animatorInfo;
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        animatorInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (animatorInfo.IsName("PlayerAttackA"))//注意这里指的不是动画的名字而是动画状态的名字
        {
            anim.speed = 6;

        }
        else
        {
            anim.speed = 1;
        }
    }

}