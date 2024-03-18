using UnityEngine;

public class Player_State_Move : IState
{
    private ControlPlayer player;
    private Vector3 localAngle;

    public Player_State_Move(ControlPlayer player)
    {
        this.player = player;
    }

    public void Enter()
    {
        Debug.Log("�ړ���Ԃɓ�����");
        player.SetAnimation("Move");
        player.timer_noInput = 0; // timer reset
    }

    public void Execute()
    {
        float horizontal_input = Input.GetAxisRaw("Horizontal");
        float vertical_input = Input.GetAxisRaw("Vertical");

        localAngle = player.transform.localEulerAngles;
        localAngle.x = 0.0f; // ���[�J�����W����ɁAx�������ɂ�����]��10�x�ɕύX
        localAngle.y = 0.0f; // ���[�J�����W����ɁAy�������ɂ�����]��10�x�ɕύX

        // ��������
        if (horizontal_input > 0)
        {
            player.spriteRenderer.flipX = false; // �E�����ɂ���
        }
        else if (horizontal_input < 0)
        {
            player.spriteRenderer.flipX = true; // �������ɂ���
        }

        // ������Ɖ������̈ړ�����
        Vector3 moveDirection = new Vector3(horizontal_input, vertical_input, 0);
        moveDirection.Normalize(); // �ړ������𐳋K��

        //�S�����ړ�
        player.transform.position += moveDirection * player.move_speed * Time.deltaTime;

        //�����������ϊ�
        if (horizontal_input != 0 || vertical_input != 0)
        {
            if (vertical_input > 0)
            {
                if (horizontal_input > 0)
                {
                    localAngle.z = 45.0f;
                }
                else if (horizontal_input < 0)
                {
                    localAngle.z = -45.0f;
                }
                else
                {
                    player.spriteRenderer.flipX = false;
                    localAngle.z = 90.0f;
                }
            }
            else if (vertical_input < 0)
            {
                if (horizontal_input > 0)
                {
                    localAngle.z = -45.0f;
                }
                else if (horizontal_input < 0)
                {
                    localAngle.z = 45.0f;
                }
                else
                {
                    player.spriteRenderer.flipX = true;
                    localAngle.z = 90.0f;
                }
            }
            else
            {
                localAngle.z = 0.0f;
            }

            player.transform.localEulerAngles = localAngle;

            player.localAngle = localAngle;
            player.DashDirection = moveDirection;
        }

        // ���͂��Ȃ����Ԃ��L�^
        if (horizontal_input == 0 && vertical_input == 0)
        {
             player.timer_noInput += Time.deltaTime;
        }

        // ��ԑJ�ځF���͂��Ȃ��ꍇ�A��莞�Ԍ�ɃA�C�h����ԂɑJ�ڂ���
        if (player.timer_noInput > player.threshold_noInput)
        {
            player.ChangeState(new Player_State_Idle(player));
        }
    }

    public void Exit()
    {

    }
}
