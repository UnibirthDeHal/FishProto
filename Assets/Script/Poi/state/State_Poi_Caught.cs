using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class State_Poi_Caught : IState
{
    private ControlPoi poi;
    private int count;
    private float caughttimer;

    public State_Poi_Caught(ControlPoi poi)
    {
        this.poi = poi;
    }

    public void Enter()
    {
        poi.timer = 0;
        poi.Nowtiming = 9;
        poi.SetAnimation("Poi_Caught");
        count = 0;
        caughttimer = 0.0f;
    }

    public void Execute()
    {
        if (Input.anyKeyDown == true)
        {
            count++;
        }

        caughttimer += Time.deltaTime;

        if (count > poi.QTECount)
        {
            poi.ChangeState(new State_Poi_Break(poi));
        }

        if (caughttimer > poi.BecaughtMaxtime)
        {
            poi.EndPoi();
        }
    }

    public void Exit()
    {

    }
}
