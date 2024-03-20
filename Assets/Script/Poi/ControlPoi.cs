using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;
using static UnityEngine.EventSystems.EventTrigger;

public class ControlPoi : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public float Badtime = 1.0f;
    public float Goodtime = 1.0f;
    public float Greattime = 0.5f;

    public int Nowtiming;
    public int QTECount = 10;
    public float BecaughtMaxtime = 3.5f;

    [HideInInspector] public float timer;

    private IState currentState;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        ChangeState(new State_Poi_Bad1(this));
    }

    void Update()
    {
        currentState?.Execute();
    }

    // 状態を変更するメソッド
    public void ChangeState(IState newState)
    {
        currentState?.Exit(); // 現在の状態の Exit を呼び出し
        currentState = newState;
        currentState.Enter(); // 新しい状態の Enter を呼び出し
    }

    public void SetAnimation(string animationName)
    {
        animator.Play(animationName);
    }

    public bool AnimationFinished(string animationName)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1.0f;
    }

    public void EndPoi()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("当たった");

        if (collision.gameObject.GetComponent<ControlPlayer>().isGoodTiming(this) == true)
        {
            Debug.Log("突き抜けた！");

            //ここに得点、コンボ数計算
            //=======================
            
            
            
            //=======================

            this.GetComponent<BoxCollider2D>().enabled = false;

            ChangeState(new State_Poi_Break(this));
        }
        else
        {
            Debug.Log("捕まった！");

            this.GetComponent<BoxCollider2D>().enabled = false;

            collision.gameObject.GetComponent<ControlPlayer>().GetCaught(this);

            ChangeState(new State_Poi_Caught(this));
        }
 
    }
}
