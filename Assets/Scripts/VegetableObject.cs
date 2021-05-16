using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableObject : MonoBehaviour
{
    public Sprite[] CookingPhases;
    [SerializeField]
    private Sprite currentPhase;
    //[SerializeField]
    //private ScoringStirFry scoreboard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateTemperature()
    {
        /*
        currentTemp = scoreboard.GetCurrentCookDegree();
        if (currentTemp >= 5400 && currentTemp < 6000)
        {
            //Phase 1 (Slightly)
            currentPhase = PancakePhases[1];
        }
        else if (currentTemp >= 6000 && currentTemp < 6200)
        {
            //Phase 2 (Perfect)
            currentPhase = PancakePhases[2];
        }
        else if (currentTemp >= 6200 && currentTemp < 6800)
        {
            //Phase 3 (Darker)
            currentPhase = PancakePhases[3];
        }
        else if (currentTemp > 6800)
        {
            //Phase 4 (Burnt)
            currentPhase = PancakePhases[4];
        }*/
    }
}
