using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestAnim : MonoBehaviour
{
    public Animator myAnim;
    public Action OnSpacePressed;

    public enum AnimEnum
    {
        none = 0,
        idle = 1,
        running = 2,
        victory = 3,
        lose = 4
    }
    public AnimEnum animEnum;

    void Start()
    {
        OnSpacePressed += ChangeAnim;
        ChangeAnim();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            OnSpacePressed?.Invoke();
        }
    }

    void ChangeAnim()
    {
        switch (animEnum)
        {
            case AnimEnum.none:
                break;
            case AnimEnum.idle:
                myAnim.SetTrigger("isIdle");
                break;
            case AnimEnum.running:
                myAnim.SetTrigger("isRunning");
                break;
            case AnimEnum.victory:
                myAnim.SetTrigger("Victory");
                break;
            case AnimEnum.lose:
                myAnim.SetTrigger("Lose");
                break;
            default:
                break;
        }
    }
}
