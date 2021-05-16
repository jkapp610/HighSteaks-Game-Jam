using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VsFlyIn : MonoBehaviour
{
    public GameObject myUI;
    private float m_Thrust = 1000000f;
    public GameObject blackscreen;
    public GameObject flypicture;
    private Rigidbody2D m_Rigidbody;
    private int waittime = 5000;
    private int currtime = 0;
    private bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        //blackscreen.SetActive(true);
        //flypicture.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!done && currtime <= waittime)
        {
            currtime++;

        }
        else if(!done)
        {
            blackscreen.SetActive(false);
            flypicture.SetActive(false);
            myUI.SetActive(true);
            done = true;
        }
        
    }
}
