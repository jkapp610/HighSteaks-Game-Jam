using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipMeter : MonoBehaviour{

     public GameObject  flipMeter;
     public GameObject Bar;
     public float speed= 3.0f;
    public float changeTime = 3.0f;
    public float timer;
    bool countdown;
    bool canmove;
     int direction =1;
     public LevelTimer mylevelTimer;
    // Start is called before the first frame update
    void Start(){
        flipMeter.SetActive(false);
         timer = changeTime;
         countdown = false;
         canmove =false;
        
       
    }

    // Update is called once per frame
    void Update(){

        if (Input.GetKeyDown(KeyCode.F)){
            flipMeter.SetActive(true);
            countdown = true;
            canmove= true;

            

            Debug.Log("F key was pressed.");
        }
        if(countdown){
            timer -= Time.deltaTime;
            if (timer < 0){
                direction = -direction;
                timer = changeTime;
            }
        }
        if(mylevelTimer.minutes==0 && mylevelTimer.seconds==0){
            flipMeter.SetActive(true);
            countdown = true;
            canmove= true;

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
