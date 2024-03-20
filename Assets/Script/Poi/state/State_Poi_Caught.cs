using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class State_Poi_Caught : IState
{
    private ControlPoi poi;

    public State_Poi_Caught(ControlPoi poi)
    {
        this.poi = poi;
    }

    public void Enter()
    {
        poi.timer = 0;
        poi.Nowtiming = 9;
        poi.SetAnimation("Poi_Caught");
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
}
