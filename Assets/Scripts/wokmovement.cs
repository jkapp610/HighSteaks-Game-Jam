using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wokmovement : MonoBehaviour{

    Vector3 mousePosition;
    public float movespeed  =0.5f;
    Rigidbody2D rigidbody2d;
    Vector2 position = new Vector2(0f,0f);
    private int cooldown = 0;
    private int maxcooldown = 600;
    private bool oncooldown = false;
    private Vector2 previousposition;
    public ScoreController score;
    public DialTurningStirFry heatmanagement;

    // Start is called before the first frame update
    void Start(){
        //QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        rigidbody2d = GetComponent<Rigidbody2D>();
        previousposition = position;
    }

    // Update is called once per frame
    void Update(){
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        position = Vector2.Lerp(transform.position,mousePosition,movespeed);
        Vector2 positionDelta = position - previousposition;
        if(!oncooldown && (positionDelta.x > 0.3f || positionDelta.y > 0.3f))
        {
            oncooldown = true;
            score.IncrementControlCount();
            Debug.Log("cooldown activated");
            heatmanagement.setCooldown(true);
        }
        previousposition = transform.position;
        if (oncooldown)
        {
            if (cooldown < maxcooldown)
            {
                cooldown++;
            }
            else
            {
                cooldown = 0;
                oncooldown = false;
                heatmanagement.setCooldown(false);
            }
        }
        
    }
    void FixedUpdate(){
        rigidbody2d.MovePosition(position);
    }
}
