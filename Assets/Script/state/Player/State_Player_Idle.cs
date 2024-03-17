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
        Debug.Log("�ҋ@��Ԃɓ�����");
        player.SetAnimation("Idle");
    }

    public void Execute()
    {

        //�y��ԑJ�ځzMove��Ԃ�
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            player.ChangeState(new Player_State_Move(player));
        }
      //if (Input.GetButtonDown("Jump"))
      //{
      //    player.ChangeState(new Player_State_Jump(player));
      //}
    }

    public void Exit()
    {

    }
}
