using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player_State_BeCaught : IState
{
    private ControlPlayer player;
    private int count;
    private float timer;

    public Player_State_BeCaught(ControlPlayer player)
    {
        this.player = player;
    }

    public void Enter()
    {
        Debug.Log("捕まれた状態に入った");
        player.SetAnimation("BeCaught");
        player.timer_noInput = 0;
        count = 0;
        timer = 0.0f;
    }

    public void Execute()
    {
        //テクスチャーの向きを保つ
        player.transform.localEulerAngles = player.localAngle;

        if (Input.anyKeyDown == true) 
        {
            count++;
        }

        timer += Time.deltaTime;

        if (count > player.QTECount)
        {
            player.ChangeState(new Player_State_Move(player));
        }

        if (timer > player.BecaughtMaxtime)
        {
            player.GameOver();
        }

    }

    public void Exit()
    {

    }
}
