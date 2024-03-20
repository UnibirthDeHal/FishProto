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
        Debug.Log("ダッシュ状態に入った");
        player.SetAnimation("Dash");
        player.timer_noInput = 0; // timer reset
        elapsedTime = 0.0f;
        player.isDash=true;
    }

    public void Execute()
    {

        // 座標移動計算（ダッシュ速度で移動）
        player.transform.position += player.DashDirection * player.move_speed * player.dashSpeedMultiplier * Time.deltaTime;

        //テクスチャーの向きを保つ
        player.transform.localEulerAngles = player.localAngle;

        // ダッシュ時間を加算
        elapsedTime += Time.deltaTime;

        // ダッシュ時間が経過したら、移動状態に戻る
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
