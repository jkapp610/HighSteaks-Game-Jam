using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipMeter : MonoBehaviour{

     public GameObject  flipMeter;
     public GameObject Bar;
    public ScoringPancake score;
     public float speed= 3.0f;
    public float changeTime = 3.0f;
    private float flipquality = 0;
    public float timer;
    private bool countdown;
    private bool canmove;
    private bool hasflipped;
     int direction =1;
     public LevelTimer mylevelTimer;
    // Start is called before the first frame update
    void Start(){
        flipMeter.SetActive(false);
         timer = changeTime;
         countdown = false;
         canmove =false;
         hasflipped = false;
        
       
    }

    // Update is called once per frame
    void Update(){
        /*
        if (Input.GetKeyDown(KeyCode.F)){
            flipMeter.SetActive(true);
            countdown = true;
            canmove= true;
            getflip = true;
            

            Debug.Log("F key was pressed.");
        }*/
        if(countdown){
            timer -= Time.deltaTime;
            if (timer < 0){
                direction = -direction;
                timer = changeTime;
            }
        }
        if(!hasflipped && mylevelTimer.minutes==0 && mylevelTimer.seconds==0){
            flipMeter.SetActive(true);
            countdown = true;
            canmove= true;


        }
        if (countdown && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("FLIP");
            if(direction == 1)
            {
                flipquality = timer;
            }
            else
            {
                flipquality = changeTime - timer;
            }
                            //Need to store a value based upon the position of the bar
                            //when left mouse is clicked.  
                            //base upon values of timer and direction
            score.SetFlipQuality(flipquality) ;
            countdown = false;
            canmove = false;
            hasflipped = true;

        }


        
    }
      void FixedUpdate(){
         if(canmove){
            Vector2 position = Bar.GetComponent<Rigidbody2D>().position;
            position.y = position.y + Time.deltaTime * speed * direction;
            Bar.GetComponent<Rigidbody2D>().MovePosition(position);
          }

    }
}
