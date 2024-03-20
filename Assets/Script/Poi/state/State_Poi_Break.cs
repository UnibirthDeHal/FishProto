using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class State_Poi_Break : IState
{
    private ControlPoi poi;

    public State_Poi_Break(ControlPoi poi)
    {
        this.poi = poi;
    }

    public void Enter()
    {
        poi.timer = 0;

        if (poi.Nowtiming == 9)
        {
            poi.SetAnimation("Poi_Break2");
        }
        else
        {
            poi.SetAnimation("Poi_Break1");
        }

        poi.Nowtiming = -1;
    }

    public void Execute()
    {
        poi.timer+=Time.deltaTime;

        if (poi.timer >= poi.Badtime)
        {
            poi.EndPoi();
        }
    }

    public void Exit()
    {

    }
}
