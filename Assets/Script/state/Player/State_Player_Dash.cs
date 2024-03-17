using UnityEngine;

public class Player_State_Dash : IState
{
    private ControlPlayer player;
    private float dashDuration;
    private float dashSpeedMultiplier;
    private float elapsedTime;

    public Player_State_Dash(ControlPlayer player, float dashDuration, float dashSpeedMultiplier)
    {
        this.player = player;
        this.dashDuration = dashDuration;
        this.dashSpeedMultiplier = dashSpeedMultiplier;
        this.elapsedTime = 0f;
    }

    public void Enter()
    {
        Debug.Log("ダッシュ状態に入った");
        player.SetAnimation("Dash");
        player.timer_noInput = 0; // timer reset
    }

    public void Execute()
    {
        float horizontal_input = Input.GetAxisRaw("Horizontal");
        float vertical_input = Input.GetAxisRaw("Vertical");

        // 座標移動計算（ダッシュ速度で移動）
        Vector3 moveDirection = new Vector3(horizontal_input, vertical_input, 0).normalized;
        player.transform.position += moveDirection * player.move_speed * dashSpeedMultiplier * Time.deltaTime;

        // ダッシュ時間を加算
        elapsedTime += Time.deltaTime;

        // ダッシュ時間が経過したら、移動状態に戻る
        if (elapsedTime >= dashDuration)
        {
            player.ChangeState(new Player_State_Idle(player));
        }
    }

    public void Exit()
    {

    }
}
