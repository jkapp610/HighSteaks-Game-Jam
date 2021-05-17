using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour
{

    //Some silly sidepanel variables

    private int panelstate = 0;
    private int panelcount = 0;
    public int paneltime = 360;
    public GameObject soufle;
    public GameObject[] credits;
/*    public GameObject credits2;
    public GameObject credits3;
    public GameObject credits4;
    public GameObject credits5;
    public GameObject credits6;*/
    private int curr = 0;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curr < credits.Length && panelstate == 0)
        {
            panelstate = 1;
            
        }
        else if (panelstate == 1 && panelcount < paneltime)
        {
            SpriteRenderer sprite = credits[curr].GetComponent<SpriteRenderer>();
            sprite.color = new Color(1, 1, 1, (panelcount / 255.0f));

            //sidepanel transparency up
            panelcount++;
        }
        else if (panelstate == 1 && panelcount == paneltime)
        {
            panelstate = 2;
        }
        else if (panelstate == 2 && panelcount >= 0 && curr != credits.Length-1)
        {
            SpriteRenderer sprite = credits[curr].GetComponent<SpriteRenderer>();
            sprite.color = new Color(1, 1, 1, (panelcount / 255.0f));
            panelcount--;
        }
        else if (panelstate == 2)
        {
            panelstate = 0;
            curr++;
        }

    }
}
