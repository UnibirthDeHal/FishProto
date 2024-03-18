using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player_State_Idle : IState
{
    private ControlPlayer player;

    public Player_State_Idle(ControlPlayer player)
    {
        this.player = player;
    }

    public void Enter()
    {
        Debug.Log("待機状態に入った");
        player.SetAnimation("Idle");
    }

    public void Execute()
    {
        //テクスチャーの向きを保つ
        player.transform.localEulerAngles = player.localAngle;

        //【状態遷移】Move状態に
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            player.ChangeState(new Player_State_Move(player));
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            player.ChangeState(new Player_State_Move(player));
        }

    }

    public void Exit()
    {

    }
}
