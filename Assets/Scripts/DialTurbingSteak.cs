using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialTurbingSteak : MonoBehaviour
{
    //public GameObject mouseCursor;
    //public StoveFlame flame;
    private float rotZ;
    public GameObject dial;
    //public RandomBubbles bubbles;
    public float speed;
    public float decayGoal;
    public float decaySpdDivisor;
    private int randInt;
    private bool clockwise;
    private bool decaying;
    Vector3 cursorPosition;
    Vector3 rotationvector;
    [SerializeField]
    private float Zval;
    bool isHoldingM1;
    // Start is called before the first frame update
    void Start()
    {
     //clockwise = true;
        decaySpdDivisor = 4;
        decayGoal = 5f;        // X = 0.0X% chance of activating each frame
        decaying = false;
        speed =100f;
    }

    // Update is called once per frame
    void Update(){
        randInt = Random.Range(0, 10000);

        Zval = dial.transform.rotation.z;

        if (randInt <= decayGoal) {
            decaying = true;
        }

        if(Zval <= -0.9996122||Input.GetKeyUp("d")||Input.GetKeyDown("a")){
            clockwise = false;
         
        }
    
        if(Zval>=0||Input.GetKeyUp("a")||Input.GetKeyDown("d")){
            clockwise = true;
            decaying = false;
        }


      
        if(clockwise ==true){
            if(Input.GetKey(KeyCode.D)){
                rotZ += -Time.deltaTime*speed;
                dial.transform.rotation = Quaternion.Euler(0,0,rotZ);
                //flame.SetFlameViaZVal(Zval);
                //bubbles.SetTempViaZVal(Zval);
            } 
        }


        if(clockwise ==false){
            if(Input.GetKey(KeyCode.A)){
                rotZ += Time.deltaTime*speed;
                dial.transform.rotation = Quaternion.Euler(0,0,rotZ);
                //flame.SetFlameViaZVal(Zval);
                //bubbles.SetTempViaZVal(Zval);
            }   

        }

        if(decaying && Zval < 0) {
            rotZ += Time.deltaTime * speed / decaySpdDivisor;
            dial.transform.rotation = Quaternion.Euler(0,0,rotZ);
            //flame.SetFlameViaZVal(Zval);
            //bubbles.SetTempViaZVal(Zval);
        }

    
        //cursorPosition = Input.mousePosition;

    }
    /*
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
    */
}

