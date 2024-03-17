using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;
using static UnityEngine.EventSystems.EventTrigger;

public class ControlPlayer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    //public float groundCheckRadius = 0.5f;
    //public LayerMask whatIsGround;
    public float dashDuration = 0.1f; // ダッシュの持続時間（デフォルトは1秒）

    public float dashSpeedMultiplier = 3f; // ダッシュ時の速度倍率

    [HideInInspector] public int dir;

    public float move_speed;
    [HideInInspector] public float timer_noInput;
    [HideInInspector] public float threshold_noInput;

    // Rigidbodyの定義を修正
    private Rigidbody rb;
    private IState currentState;
    private Transform _transform;
    // このフラグはプレイヤーが地面にいるかどうかを追跡します
    internal bool isGrounded;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); // Rigidbodyコンポーネントの取得
    }

    void Start()
    {
        _transform = transform;
        ChangeState(new Player_State_Idle(this));
    }

    void Update()
    {
        currentState?.Execute();

        //CheckGroundedStatus();

        //// ジャンプ入力の検出
        //if (Input.GetKey(KeyCode.Space) && isGrounded)
        //{
        //    ChangeState(new Player_State_Jump(this));
        //}
        // スペースキーが押され、かつ移動状態である場合にダッシュ状態に遷移する
        if (Input.GetKeyDown(KeyCode.Space) && currentState is Player_State_Move)
        {
            ChangeState(new Player_State_Dash(this, dashDuration, dashSpeedMultiplier));
        }
    }

   //void CheckGroundedStatus()
   //{
   //    Vector3 rayStart = groundCheck.position;
   //    Vector3 rayDirection = Vector3.down;
   //    float rayLength = 1f; // 適宜調整
   //    RaycastHit hit;
   //
   //    isGrounded = Physics.Raycast(rayStart, rayDirection, out hit, rayLength, whatIsGround);
   //
   //    // デバッグ用にレイをシーンに表示
   //    Debug.DrawRay(rayStart, rayDirection * rayLength, isGrounded ? Color.green : Color.red);
   //}

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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("竜遺伝子"))
        {
            // Itemとの接触時の処理をここに記述

            //ここに竜遺伝子を吸収したことを変異状況管理へ報告

            Destroy(other.gameObject); // 例: Itemを消去する
        }
        if (other.CompareTag("魚遺伝子"))
        {
            // Itemとの接触時の処理をここに記述

            //ここに魚遺伝子を吸収したことを変異状況管理へ報告

            Destroy(other.gameObject); // 例: Itemを消去する
        }
        if (other.CompareTag("ネズミ遺伝子"))
        {
            // Itemとの接触時の処理をここに記述

            //ここにネズミ遺伝子を吸収したことを変異状況管理へ報告

            Destroy(other.gameObject); // 例: Itemを消去する
        }
        if (other.CompareTag("亀遺伝子"))
        {
            // Itemとの接触時の処理をここに記述

            //ここに亀遺伝子を吸収したことを変異状況管理へ報告

            Destroy(other.gameObject); // 例: Itemを消去する
        }
    }
}
