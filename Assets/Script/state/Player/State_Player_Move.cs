using UnityEngine;

public class Player_State_Move : IState
{
    private ControlPlayer player;

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

        // ������ړ�
        if (vertical_input > 0)
        {
            player.transform.position += Vector3.up * player.move_speed * Time.deltaTime;
        }
        // �������ړ�
        else if (vertical_input < 0)
        {
            player.transform.position -= Vector3.up * player.move_speed * Time.deltaTime;
        }
        // ���������̈ړ�
        else
        {
            player.transform.position += moveDirection * player.move_speed * Time.deltaTime;
        }

        // ���͂��Ȃ��ꍇ�A�A�C�h����ԂɑJ�ڂ���
        if (horizontal_input == 0 && vertical_input == 0)
        {
            player.ChangeState(new Player_State_Idle(player));
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
