using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringPancake : MonoBehaviour
{
    private double heatincrement = 0;
    private double totalheat = 0;
    private double myFlipLocation = 0;
    private bool displayscore = false;
    private int numcontrols = 0;
    public DisplayScore scoreboard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalheat += heatincrement;
        //Debug.Log(myFlipLocation + " : flip location");
        if (displayscore)
        {
            displayscore = false;
            scoreboard.runDisplay(totalheat,myFlipLocation,numcontrols);
        }
    }

    public void SetHeatIncrementViaZVal(float dialZVal)
    {
        heatincrement = Mathf.Abs(dialZVal);
    }

    public void SetFlipQuality(float flipLocation)
    {
        myFlipLocation = flipLocation;
        displayscore = true;
    }

    public void IncrementControlCount()
    {
        numcontrols++;
    }

    public double GetCurrentCookDegree()
    {
        return totalheat;
    }
}
