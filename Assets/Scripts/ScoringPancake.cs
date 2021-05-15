using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringPancake : MonoBehaviour
{
    private double heatincrement = 0;
    private double totalheat = 0;
    private double myFlipLocation = 0;
/*  private double upperlimit_s = 6200;
    private double lowerlimit_s = 6000;
    private double upperlimit_a = 6400;
    private double lowerlimit_a = 5800;
    private double upperlimit_b = 6600;
    private double lowerlimit_b = 5600;
    private double upperlimit_c = 6800;
    private double lowerlimit_c = 5400;
    private double flipmin = 0.49f;         */
    private bool displayscore = false;
    private int numcontrols = 0;
    //private int maxcontrols = 3;
    public DisplayScore scoreboard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalheat += heatincrement;
        Debug.Log(myFlipLocation + " : flip location");
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
}
