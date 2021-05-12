using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wokmovement : MonoBehaviour{

    Vector3 mousePosition;
    public float movespeed  =0.1f;
    Rigidbody2D rigidbody;
    Vector2 position = new Vector2(0f,0f);

    // Start is called before the first frame update
    void Start(){
          rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update(){
         mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        position= Vector2.Lerp(transform.position,mousePosition,movespeed);
        
    }
    void FixedUpdate(){
        rigidbody.MovePosition(position);
    }
}
