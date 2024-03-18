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
        Debug.Log("移動状態に入った");
        player.SetAnimation("Move");
        player.timer_noInput = 0; // timer reset
    }

    public void Execute()
    {
        float horizontal_input = Input.GetAxisRaw("Horizontal");
        float vertical_input = Input.GetAxisRaw("Vertical");

        localAngle = player.transform.localEulerAngles;
        localAngle.x = 0.0f; // ローカル座標を基準に、x軸を軸にした回転を10度に変更
        localAngle.y = 0.0f; // ローカル座標を基準に、y軸を軸にした回転を10度に変更

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

        //全方向移動
        player.transform.position += moveDirection * player.move_speed * Time.deltaTime;

        //八方向向き変換
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

        // 入力がない時間を記録
        if (horizontal_input == 0 && vertical_input == 0)
        {
             player.timer_noInput += Time.deltaTime;
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
