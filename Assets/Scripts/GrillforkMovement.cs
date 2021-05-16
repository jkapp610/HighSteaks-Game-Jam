using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillforkMovement : MonoBehaviour
{
   Vector3 mousePosition;
    public float movespeed  =0.1f;
    Rigidbody2D rigidbody;
    Vector2 position = new Vector2(0f,0f);
    public float time = 10f;
    public float currenttime = 0;
   public bool canmove;
    public ScoreController score;

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


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "steak")
        {
            if (Input.GetMouseButtonDown(0))
            {
                //position = new Vector2(3.8166f,-4.585f);
                //rigidbody.MovePosition(position);
                currenttime = 0;
                canmove = false;
                score.IncrementControlCount();

            }
        }
    }
}
