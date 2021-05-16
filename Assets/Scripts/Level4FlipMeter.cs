using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4FlipMeter : MonoBehaviour
{


       public GameObject  flipMeter;
     public GameObject Bar;
    public ScoringPancake score;
     public OvenPower power;
    public float speed= 3.0f;
    public float changeTime = 3.0f;
    private float flipquality = 0;
    public float timer;
    private bool countdown;
    private bool canmove;
    private bool hasflipped;
     int direction =1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){


        if(countdown){
            timer -= Time.deltaTime;
            if (timer < 0){
                direction = -direction;
                timer = changeTime;
            }
        
        }
         if(!hasflipped &&( power.getlostpower()) && Input.GetKeyDown(KeyCode.O)){

         }

    }
}
