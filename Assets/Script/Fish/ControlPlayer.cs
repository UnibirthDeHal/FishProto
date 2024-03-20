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
    public float dashDuration = 0.5f; // �_�b�V���̎������ԁi�f�t�H���g��1�b�j

    public float dashSpeedMultiplier = 4f; // �_�b�V�����̑��x�{��

    public int QTECount = 10;
    public float BecaughtMaxtime = 3.0f;

    [HideInInspector] public bool isDash ;
    [HideInInspector] public float timer_noInput;
    [HideInInspector] public float threshold_noInput;
    [HideInInspector] public Vector3 localAngle;
    [HideInInspector] public Vector3 DashDirection;

    // Rigidbody�̒�`���C��
    private Rigidbody rb;
    private IState currentState;
    private Transform _transform;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); // Rigidbody�R���|�[�l���g�̎擾
    }

    void Start()
    {
        //������
        timer_noInput = 0;
        threshold_noInput = 0.1f;
        isDash = false;

        _transform = transform;
        ChangeState(new Player_State_Idle(this));
    }

    void Update()
    {
        currentState?.Execute();

        // �X�y�[�X�L�[��������A���ړ���Ԃł���ꍇ�Ƀ_�b�V����ԂɑJ�ڂ���
        if (Input.GetKeyDown(KeyCode.Space) && currentState is Player_State_Move)
        {
            ChangeState(new Player_State_Dash(this));
        }
    }

    // ��Ԃ�ύX���郁�\�b�h
    public void ChangeState(IState newState)
    {
        currentState?.Exit(); // ���݂̏�Ԃ� Exit ���Ăяo��
        currentState = newState;
        currentState.Enter(); // �V������Ԃ� Enter ���Ăяo��
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
