using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakeObject : MonoBehaviour
{
    [SerializeField]
    private ScoringPancake scoreboard;
    [SerializeField]
    private double currentTemp;
    private int cookingSidePhase = 0;
    public Sprite[] PancakePhases;
    [SerializeField]
    private Sprite currentPhase;

    public GameObject peekSide;
    public GameObject otherSide;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreboard = GetComponentInParent<ScoringPancake>();
        currentPhase = PancakePhases[0];
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTemperature();
    }

    private void UpdateTemperature()
    {
        currentTemp = scoreboard.GetCurrentCookDegree();
        if(currentTemp >= 5400 && currentTemp < 6000)
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
        }
    }

    public void CheckPancake()
    {
        peekSide.transform.Rotate(10f, 0f, 0f);
        peekSide.GetComponent<SpriteRenderer>().color = new Color(.9f, .9f, .9f, 1f);
    }

    public void EndCheck()
    {
        peekSide.transform.Rotate(-10f, 0f, 0f);
        peekSide.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

    public void StartFlip()
    {

    }
}
