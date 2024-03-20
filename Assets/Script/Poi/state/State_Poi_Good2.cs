using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class State_Poi_Good2 : IState
{
    private ControlPoi poi;

    public State_Poi_Good2(ControlPoi poi)
    {
        this.poi = poi;
    }

    public void Enter()
    {
        poi.timer = 0;
        poi.Nowtiming = 1;
        poi.SetAnimation("Poi_Good2");
    }

    public void Execute()
    {
        poi.timer += Time.deltaTime;

        if (poi.timer >= poi.Goodtime)
        {
            poi.ChangeState(new State_Poi_Bad2(poi));
        }
    }

    public void Exit()
    {

    }
}
