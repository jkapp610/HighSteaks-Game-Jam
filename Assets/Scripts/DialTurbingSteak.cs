using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialTurbingSteak : MonoBehaviour
{
    //public StoveFlame flame;
    private float rotZ = 359f;
    public GameObject dial;
    //public RandomBubbles bubbles;
    public ScoreController score;
    public float speed;
    public float decayGoal;
    public float decaySpdDivisor;
    private int randInt;
    private bool clockwise;
    [SerializeField]
    private bool decaying;
    Vector3 cursorPosition;
    Vector3 rotationvector;
    [SerializeField]
    private float Zval;
    public float ZvaleulerAngle;
    bool isHoldingM1;
    // Start is called before the first frame update
    void Start()
    {
     //clockwise = true;
        decaySpdDivisor = 4;
        decayGoal = 5f;        // X = 0.0X% chance of activating each frame
        decaying = false;
    }

    // Update is called once per frame
    void Update(){
        randInt = Random.Range(0, 10000);

        if (randInt <= decayGoal)
        {
            decaying = true;
        }

        if(Zval <= 0 || Input.GetAxis("Horizontal") != 0)
        {
            decaying = false;
        }

        Zval = dial.transform.rotation.z;
        //ZvaleulerAngle = dial.transform.localRotation.eulerAngles.z;
        rotZ += Input.GetAxis("Horizontal") * -2;

        if (decaying && Zval > 0)
        {
            Debug.Log("Decay!");
            rotZ += Time.deltaTime * speed / decaySpdDivisor;
        }

        rotZ = Mathf.Clamp(rotZ, 180, 360);

        dial.transform.rotation = Quaternion.Euler(0, 0, rotZ);
        //flame.SetFlameViaZVal(Zval);
        //bubbles.SetTempViaZVal(Zval);
        score.SetHeatIncrementViaZVal(Zval);

    }
}

