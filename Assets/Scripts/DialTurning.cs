using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialTurning : MonoBehaviour
{
    public GameObject mouseCursor;
    Vector3 cursorPosition;
    [SerializeField]
    bool isHoldingM1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
