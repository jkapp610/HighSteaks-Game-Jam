using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialTurning : MonoBehaviour
{
    public GameObject mouseCursor;
    private float rotZ;
    public GameObject dial;
    public float speed;
    private bool clockwise;
    Vector3 cursorPosition;
    Vector3 rotationvector;
    [SerializeField]
    private float Zval;
    bool isHoldingM1;
    // Start is called before the first frame update
    void Start()
    {
     clockwise = true;
        
    }

    // Update is called once per frame
    void Update(){


        Zval = dial.transform.rotation.z;

    if(Zval <= -0.9996122){
            clockwise = false;
        }
    if(Zval>=0){
        clockwise = true;
    }


      
        
       if(clockwise ==true){
          if(Input.GetKey(KeyCode.D)){
                rotZ += -Time.deltaTime*speed;
                dial.transform.rotation = Quaternion.Euler(0,0,rotZ);
                


             

            } 
        }


        if(clockwise ==false){
            
       
  
        
            if(Input.GetKey(KeyCode.A)){
                rotZ += Time.deltaTime*speed;
                dial.transform.rotation = Quaternion.Euler(0,0,rotZ);
             

            }   

        }



    
        cursorPosition = Input.mousePosition;

    }

    void GetMouseControls()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isHoldingM1 = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isHoldingM1 = false;
        }
    }
}
