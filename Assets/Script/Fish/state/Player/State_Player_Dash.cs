using UnityEngine;

public class Player_State_Dash : IState
{
    private ControlPlayer player;
    private float elapsedTime;

    public Player_State_Dash(ControlPlayer player)
    {
        this.player = player;
    }

    public void Enter()
    {
        Debug.Log("�_�b�V����Ԃɓ�����");
        player.SetAnimation("Dash");
        player.timer_noInput = 0; // timer reset
        elapsedTime = 0.0f;
        player.isDash=true;
    }

    public void Execute()
    {

        // ���W�ړ��v�Z�i�_�b�V�����x�ňړ��j
        player.transform.position += player.DashDirection * player.move_speed * player.dashSpeedMultiplier * Time.deltaTime;

        //�e�N�X�`���[�̌�����ۂ�
        player.transform.localEulerAngles = player.localAngle;

        // �_�b�V�����Ԃ����Z
        elapsedTime += Time.deltaTime;

        // �_�b�V�����Ԃ��o�߂�����A�ړ���Ԃɖ߂�
        if (elapsedTime >= player.dashDuration)
        {
            player.ChangeState(new Player_State_Idle(player));
        }
    }

    public void Exit()
    {
        player.isDash = false;
    }
}
