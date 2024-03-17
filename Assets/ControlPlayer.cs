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
    public float dashDuration = 0.1f; // �_�b�V���̎������ԁi�f�t�H���g��1�b�j

    public float dashSpeedMultiplier = 3f; // �_�b�V�����̑��x�{��

    [HideInInspector] public int dir;

    public float move_speed;
    [HideInInspector] public float timer_noInput;
    [HideInInspector] public float threshold_noInput;

    // Rigidbody�̒�`���C��
    private Rigidbody rb;
    private IState currentState;
    private Transform _transform;
    // ���̃t���O�̓v���C���[���n�ʂɂ��邩�ǂ�����ǐՂ��܂�
    internal bool isGrounded;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); // Rigidbody�R���|�[�l���g�̎擾
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

        //// �W�����v���͂̌��o
        //if (Input.GetKey(KeyCode.Space) && isGrounded)
        //{
        //    ChangeState(new Player_State_Jump(this));
        //}
        // �X�y�[�X�L�[��������A���ړ���Ԃł���ꍇ�Ƀ_�b�V����ԂɑJ�ڂ���
        if (Input.GetKeyDown(KeyCode.Space) && currentState is Player_State_Move)
        {
            ChangeState(new Player_State_Dash(this, dashDuration, dashSpeedMultiplier));
        }
    }

   //void CheckGroundedStatus()
   //{
   //    Vector3 rayStart = groundCheck.position;
   //    Vector3 rayDirection = Vector3.down;
   //    float rayLength = 1f; // �K�X����
   //    RaycastHit hit;
   //
   //    isGrounded = Physics.Raycast(rayStart, rayDirection, out hit, rayLength, whatIsGround);
   //
   //    // �f�o�b�O�p�Ƀ��C���V�[���ɕ\��
   //    Debug.DrawRay(rayStart, rayDirection * rayLength, isGrounded ? Color.green : Color.red);
   //}

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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("����`�q"))
        {
            // Item�Ƃ̐ڐG���̏����������ɋL�q

            //�����ɗ���`�q���z���������Ƃ�ψُ󋵊Ǘ��֕�

            Destroy(other.gameObject); // ��: Item����������
        }
        if (other.CompareTag("����`�q"))
        {
            // Item�Ƃ̐ڐG���̏����������ɋL�q

            //�����ɋ���`�q���z���������Ƃ�ψُ󋵊Ǘ��֕�

            Destroy(other.gameObject); // ��: Item����������
        }
        if (other.CompareTag("�l�Y�~��`�q"))
        {
            // Item�Ƃ̐ڐG���̏����������ɋL�q

            //�����Ƀl�Y�~��`�q���z���������Ƃ�ψُ󋵊Ǘ��֕�

            Destroy(other.gameObject); // ��: Item����������
        }
        if (other.CompareTag("�T��`�q"))
        {
            // Item�Ƃ̐ڐG���̏����������ɋL�q

            //�����ɋT��`�q���z���������Ƃ�ψُ󋵊Ǘ��֕�

            Destroy(other.gameObject); // ��: Item����������
        }
    }
}
