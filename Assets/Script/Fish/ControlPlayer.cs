using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.Progress;
using static UnityEngine.EventSystems.EventTrigger;

public class ControlPlayer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public float move_speed = 5f;
    public float dashDuration = 0.5f; // ダッシュの持続時間（デフォルトは1秒）

    public float dashSpeedMultiplier = 4f; // ダッシュ時の速度倍率

    public int QTECount = 10;
    public float BecaughtMaxtime = 3.0f;

    [HideInInspector] public bool isDash ;
    [HideInInspector] public float timer_noInput;
    [HideInInspector] public float threshold_noInput;
    [HideInInspector] public Vector3 localAngle;
    [HideInInspector] public Vector3 DashDirection;

    // Rigidbodyの定義を修正
    private Rigidbody rb;
    private IState currentState;
    private Transform _transform;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); // Rigidbodyコンポーネントの取得
    }

    void Start()
    {
        //初期化
        timer_noInput = 0;
        threshold_noInput = 0.1f;
        isDash = false;

        _transform = transform;
        ChangeState(new Player_State_Idle(this));
    }

    void Update()
    {
        currentState?.Execute();

        // スペースキーが押され、かつ移動状態である場合にダッシュ状態に遷移する
        if (Input.GetKeyDown(KeyCode.Space) && currentState is Player_State_Move)
        {
            ChangeState(new Player_State_Dash(this));
        }
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
    public void GameOver()
    {
        Destroy(this.gameObject);
    }

    public bool isGoodTiming(ControlPoi poi)
    {
        if (isDash == true) 
        {
            if ((poi.Nowtiming == 1) || (poi.Nowtiming == 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void GetCaught(ControlPoi poi)
    {
        this.transform.position = poi.transform.position;

        ChangeState(new Player_State_BeCaught(this));
    }
}
