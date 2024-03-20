using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class State_Poi_Good1 : IState
{
    private ControlPoi poi;

    public State_Poi_Good1(ControlPoi poi)
    {
        this.poi = poi;
    }

    public void Enter()
    {
        poi.timer = 0;
        poi.Nowtiming = 1;
        poi.SetAnimation("Poi_Good1");
    }

    public void Execute()
    {
        poi.timer += Time.deltaTime;

        if (poi.timer >= poi.Goodtime)
        {
            poi.ChangeState(new State_Poi_Great(poi));
        }
    }

    public void Exit()
    {

    }
}
