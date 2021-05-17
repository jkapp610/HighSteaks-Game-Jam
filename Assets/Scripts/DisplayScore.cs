using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisplayScore : MonoBehaviour
{
    public double heat_upperlimit_s = 6200;
    public double heat_lowerlimit_s = 6000;
    public double heat_upperlimit_a = 6400;
    public double heat_lowerlimit_a = 5800;
    public double heat_upperlimit_b = 6600;
    public double heat_lowerlimit_b = 5600;
    public double heat_upperlimit_c = 6800;
    public double heat_lowerlimit_c = 5400;
    public double flipmin_s = 0.1f;
    public double flipmin_a = 0.49f;
    public double flipmin_b = 0.7f;
    public double flipmin_c = 1.0f;
    public int contollimit_s = 0;
    public int contollimit_a = 2;
    public int contollimit_b = 4;
    public int contollimit_c = 6;
    public bool controlminimize = true;
    private int heatscore = 0;  //1: S, 2: A, 3: B, 4: C, 5: F
    private int flipscore = 0;  //1: S, 2: A, 3: B, 4: C, 5: F
    private int controlscore = 0;  //1: S, 2: A, 3: B, 4: C, 5: F

    public GameObject myUI;
    public GameObject blackscreen;
    public GameObject scoreboard;

    public GameObject heat_icon_S;
    public GameObject heat_icon_A;
    public GameObject heat_icon_B;
    public GameObject heat_icon_C;
    public GameObject heat_icon_F;
    public GameObject heat_icon_NA;

    public GameObject flip_icon_S;
    public GameObject flip_icon_A;
    public GameObject flip_icon_B;
    public GameObject flip_icon_C;
    public GameObject flip_icon_F;
    public GameObject flip_icon_NA;

    public GameObject control_icon_S;
    public GameObject control_icon_A;
    public GameObject control_icon_B;
    public GameObject control_icon_C;
    public GameObject control_icon_F;
    public GameObject control_icon_NA;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void runDisplay(double heat, double flip, int control)
    {
        myUI.SetActive(false); //Not working
        blackscreen.SetActive(true);
        scoreboard.SetActive(true);
        if(heat < 0)
        {
            heatscore = 0; //NA
            heat_icon_NA.SetActive(true);
        }
        else if(heat <= heat_upperlimit_s && heat >= heat_lowerlimit_s)
        {
            heatscore = 1;  //S
            heat_icon_S.SetActive(true);
        }
        else if(heat <= heat_upperlimit_a && heat >= heat_lowerlimit_a)
        {
            heatscore = 2;  //A
            heat_icon_A.SetActive(true);
        }
        else if(heat <= heat_upperlimit_b && heat >= heat_lowerlimit_b)
        {
            heatscore = 3; //B
            heat_icon_B.SetActive(true);
        }
        else if(heat <= heat_upperlimit_c && heat >= heat_lowerlimit_c)
        {
            heatscore = 4; //C
            heat_icon_C.SetActive(true);
        }
        else
        {
            heatscore = 5; //F
            heat_icon_F.SetActive(true);
        }


        if (flip < 0)
        {
            flipscore = 0; //NA
            flip_icon_NA.SetActive(true);
        }
        else if (flip <= flipmin_s)
        {
            flipscore = 1; //S
            flip_icon_S.SetActive(true);
        }
        else if(flip <= flipmin_a)
        {
            flipscore = 2; //A
            flip_icon_A.SetActive(true);
        }
        else if(flip <= flipmin_b)
        {
            flipscore = 3; //B
            flip_icon_B.SetActive(true);
        }
        else if(flip <= flipmin_c)
        {
            flipscore = 4; //C
            flip_icon_C.SetActive(true);
        }
        else
        {
            flipscore = 5;
            flip_icon_F.SetActive(true);
        }

        if(control < 0)
        {
            controlscore = 0;
            control_icon_NA.SetActive(true);
        }
        else if (controlminimize)    //for minimizing number of control actions. 
                                //used for pancake and steak levels.
        {
            if (control <= contollimit_s)
            {
                controlscore = 1; //S
                control_icon_S.SetActive(true);
            }
            else if (control <= contollimit_a)
            {
                controlscore = 2; //A
                control_icon_A.SetActive(true);
            }
            else if (control <= contollimit_b)
            {
                controlscore = 3; //B
                control_icon_B.SetActive(true);
            }
            else if (control <= contollimit_c)
            {
                controlscore = 4; //C
                control_icon_C.SetActive(true);
            }
            else
            {
                controlscore = 5; //F
                control_icon_F.SetActive(true);
            }
        }
        else  //for maximizing number of controls instead.
              //used for stirfry level.
        {
            if (control >= contollimit_s)
            {
                controlscore = 1; //S
                control_icon_S.SetActive(true);
            }
            else if (control >= contollimit_a)
            {
                controlscore = 2; //A
                control_icon_A.SetActive(true);
            }
            else if (control >= contollimit_b)
            {
                controlscore = 3; //B
                control_icon_B.SetActive(true);
            }
            else if (control >= contollimit_c)
            {
                controlscore = 4; //C
                control_icon_C.SetActive(true);
            }
            else
            {
                controlscore = 5; //F
                control_icon_F.SetActive(true);
            }
        }


        Debug.Log(heatscore + " Heat Score");
        Debug.Log(flipscore + " Flip Score");
        Debug.Log(controlscore + " Control Score");

    }
}
