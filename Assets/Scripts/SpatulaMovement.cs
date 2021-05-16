using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatulaMovement : MonoBehaviour{
    Vector3 mousePosition;
    public float movespeed  =0.1f;
    private Rigidbody2D rigidbody2d;
    public float time = 3f;
    public float currenttime = 0;
    public bool canmove;
    public ScoringPancake score;
    public GameObject pancake;
    private bool pancakeSet = false;
    Vector2 position = new Vector2(0f,0f);
    public Sprite[] pancakeCheckSprites;
    public GameObject pancakeCheckUIImage;
    public GameObject pancakeCheckUI;
    private bool beganPeeking;
    public GameObject flipUI;
    private bool flipStarted;

    // Start is called before the first frame update
    void Start(){
        rigidbody2d = GetComponent<Rigidbody2D>();
        currenttime =time;
        canmove = true;
        beganPeeking = false;
        flipStarted = false;
    } 

    // Update is called once per frame
    void Update(){
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        position = Vector2.Lerp(transform.position,mousePosition,movespeed);
        currenttime += 1*Time.deltaTime;
        if(currenttime > time){
            if(beganPeeking == true)
            {
                PeekEvent();
            }
            canmove=true;
        }
        //CheckForPancake();
        if(!flipUI.activeInHierarchy)
        {
            if (canmove)
            {
                pancakeCheckUI.SetActive(false);
                updateCheckUI();
            }
            else
            {
                pancakeCheckUI.SetActive(true);
            }
        }
        else
        {
            pancakeCheckUI.SetActive(false);
        }
        



    }
    void FixedUpdate(){
       
        if(!flipUI.activeInHierarchy)
        {
            if (canmove)
            {
                rigidbody2d.MovePosition(position);
                GetComponent<SpriteRenderer>().sortingOrder = 20;
                CheckForPancake();
            }
            if (Input.GetMouseButtonDown(0) && canmove && !pancake.GetComponent<PancakeObject>().stillPouring)
            {
                position = new Vector2(3.0f, -6.459f);
                GetComponent<SpriteRenderer>().sortingOrder = 14;
                rigidbody2d.MovePosition(position);
                currenttime = 0;
                canmove = false;
                score.IncrementControlCount();
                PeekEvent();
            }
        }
        else
        {
            Flip();
            if(pancake.GetComponent<PancakeObject>().GetIsFlipping())
            {
                transform.localPosition = transform.localPosition - new Vector3(-0.03f, 0.05f, 0);
            }

        }

        //x 4.1335 //y -6459
    }

    private void updateCheckUI()
    {
        double currentTemp = score.GetCurrentCookDegree();
        if (currentTemp >= 5400 && currentTemp < 6000)
        {
            //Phase 1 (Slightly)
            pancakeCheckUIImage.GetComponent<SpriteRenderer>().sprite = pancakeCheckSprites[1];
        }
        else if (currentTemp >= 6000 && currentTemp < 6200)
        {
            //Phase 2 (Perfect)
            pancakeCheckUIImage.GetComponent<SpriteRenderer>().sprite = pancakeCheckSprites[2];
        }
        else if (currentTemp >= 6200 && currentTemp < 6800)
        {
            //Phase 3 (Darker)
            pancakeCheckUIImage.GetComponent<SpriteRenderer>().sprite = pancakeCheckSprites[3];
        }
        else if (currentTemp > 6800)
        {
            //Phase 4 (Burnt)
            pancakeCheckUIImage.GetComponent<SpriteRenderer>().sprite = pancakeCheckSprites[4];
        }
    }

    private void CheckForPancake()
    {
        if (pancake == null)
        {
            pancake = GameObject.FindWithTag("Pancake");
        }
    }

    private void PeekEvent()
    {
        CheckForPancake();
            if (beganPeeking == false)
            {
                beganPeeking = true;
                pancake.GetComponent<PancakeObject>().CheckPancake();
            }
            else
            {
                beganPeeking = false;
                pancake.GetComponent<PancakeObject>().EndCheck();
            }
        
    }

    public void Flip()
    {
        if(!flipStarted)
        {
            if(beganPeeking == true)
            {
                PeekEvent();
            }
            //pancakeCheckUI.SetActive(false);
            //pancakeCheckUIImage.SetActive(false);
            flipStarted = true;
            position = new Vector2(2.0f, -4f);
            GetComponent<SpriteRenderer>().sortingOrder = 14;
            rigidbody2d.MovePosition(position);
            currenttime = -3000f;
        }
        
    }
    
}
