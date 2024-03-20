using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class State_Poi_Great : IState
{
    private ControlPoi poi;

    public State_Poi_Great(ControlPoi poi)
    {
        this.poi = poi;
    }

    public void Enter()
    {
        poi.timer = 0;
        poi.Nowtiming = 2;
        poi.SetAnimation("Poi_Great");
    }

    public void Execute()
    {
        poi.timer += Time.deltaTime;

        if (poi.timer >= poi.Greattime)
        {
            poi.ChangeState(new State_Poi_Good2(poi));
        }
    }

    public void Exit()
    {

    }
}
