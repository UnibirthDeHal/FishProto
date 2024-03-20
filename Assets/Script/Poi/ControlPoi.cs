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

    public void EndPoi()
    {
        Destroy(this.gameObject);
    }
}
