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
        Debug.Log("移動状態に入った");
        player.SetAnimation("Move");
        player.timer_noInput = 0; // timer reset
    }

    public void Execute()
    {
        float horizontal_input = Input.GetAxisRaw("Horizontal");
        float vertical_input = Input.GetAxisRaw("Vertical");

        // 向き調整
        if (horizontal_input > 0)
        {
            player.spriteRenderer.flipX = false; // 右向きにする
        }
        else if (horizontal_input < 0)
        {
            player.spriteRenderer.flipX = true; // 左向きにする
        }

        // 上向きと下向きの移動判定
        Vector3 moveDirection = new Vector3(horizontal_input, vertical_input, 0);
        moveDirection.Normalize(); // 移動方向を正規化

        // 上向き移動
        if (vertical_input > 0)
        {
            player.transform.position += Vector3.up * player.move_speed * Time.deltaTime;
        }
        // 下向き移動
        else if (vertical_input < 0)
        {
            player.transform.position -= Vector3.up * player.move_speed * Time.deltaTime;
        }
        // 水平方向の移動
        else
        {
            player.transform.position += moveDirection * player.move_speed * Time.deltaTime;
        }

        // 入力がない場合、アイドル状態に遷移する
        if (horizontal_input == 0 && vertical_input == 0)
        {
            player.ChangeState(new Player_State_Idle(player));
        }

        // 状態遷移：入力がない場合、一定時間後にアイドル状態に遷移する
        if (player.timer_noInput > player.threshold_noInput)
        {
            player.ChangeState(new Player_State_Idle(player));
        }
    }

    public void Exit()
    {

    }
}
