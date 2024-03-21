using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagement : MonoBehaviour
{
    public int Score=0;
    public int Money=1000;
    public int Combo=0;

    public int Basescore = 100;
    public int Basemoney = 50;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        Money = 1000;
        Combo = 0;
    }

    private void Update()
    {
        
    }

    public void ScoreUP(int Timing)
    {
        Score += Timing * Basescore;
        Money += Basemoney;
        Combo++;
    }

    public void ComboDown()
    {
        Combo = 0;
    }
}
