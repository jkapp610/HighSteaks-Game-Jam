using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatulaMovement : MonoBehaviour{
    Vector3 mousePosition;
    public float movespeed  =0.1f;
    Rigidbody2D rigidbody;
     public float time = 10f;
    public float currenttime = 0;
   public bool canmove;
    public ScoringPancake score;

    Vector2 position = new Vector2(0f,0f);


    // Start is called before the first frame update
    void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
        currenttime =time;
        canmove = true;
    } 

    // Update is called once per frame
    void Update(){
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        position= Vector2.Lerp(transform.position,mousePosition,movespeed);
         currenttime+= 1*Time.deltaTime;
         if(currenttime>time){
             canmove=true;
         }
        




    }
    void FixedUpdate(){
       

        if (canmove){
            rigidbody.MovePosition(position);

        }

       

         if (Input.GetMouseButtonDown(0) && canmove){

          
            
             position = new Vector2(4.1335f,-6.459f);
             rigidbody.MovePosition(position);
             currenttime =0;
             canmove =false;
             score.IncrementControlCount();

         }

        //x 4.1335 //y -6459
    }
}
