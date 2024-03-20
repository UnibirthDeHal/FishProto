using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class State_Poi_Bad2 : IState
{
    private ControlPoi poi;

    public State_Poi_Bad2(ControlPoi poi)
    {
        this.poi = poi;
    }

    public void Enter()
    {
        poi.timer = 0;
        poi.Nowtiming = 0;
        poi.SetAnimation("Poi_Bad2");
    }

    public void Execute()
    {
        poi.timer += Time.deltaTime;

        if (poi.timer >= poi.Badtime)
        {
            poi.EndPoi();
        }
    }

    public void Exit()
    {

    }
}
