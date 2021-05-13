using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VsFlyIn : MonoBehaviour
{
    public GameObject pancakeUI;
    public float m_Thrust = 1000000f;
    public GameObject blackscreen;
    public GameObject flypicture;
    private Rigidbody2D m_Rigidbody;
    public int waittime = 5000;
    private int currtime = 0;

    // Start is called before the first frame update
    void Start()
    {
        //blackscreen.SetActive(true);
        //flypicture.SetActive(true);
        m_Rigidbody = flypicture.GetComponent<Rigidbody2D>();
        m_Rigidbody.AddForce(Vector2.up * m_Thrust);

    }

    // Update is called once per frame
    void Update()
    {
        if(currtime <= waittime)
        {
            currtime++;

        }
        else
        {
            blackscreen.SetActive(false);
            flypicture.SetActive(false);
            pancakeUI.SetActive(true);
        }
        
    }
}
