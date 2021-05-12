using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    //Timers for each level:
    //Pancake: 2 minutes
    //Stir Fry: 3 minutes, flips at 2:15, 1:00 0:15
    //Steak: 3:30 minutes
    //Souffle: 10 minutes

    //public GameObject timerDisplay;
    public Text timerText;
    public int minutes, seconds;
    private float secondTimer = 60f;
    private float flashingTimer = 0.5f;
    private bool textOn = true;
    // Start is called before the first frame update
    void Start()
    {
        SetTimer(minutes, seconds);

    }

    // Update is called once per frame
    void Update()
    {
        if(minutes >= 0)
        {
            SetTimerText();
            secondTimer -= Time.deltaTime;
            if (secondTimer <= 0f)
            {
                minutes--;
                secondTimer = 60f;
            }
            seconds = Mathf.RoundToInt(Mathf.Clamp(Mathf.Round(secondTimer), 0f, 59f));
        }
        else
        {
            timerText.text = "0:00";
            flashingTimer -= Time.deltaTime;
            if(flashingTimer <= 0f)
            {
                flashingTimer = 0.5f;
                if(!textOn)
                {
                    timerText.color = new Color(1, 1, 1, 1);
                    textOn = true;
                }
                else
                {
                    timerText.color = new Color(1, 1, 1, 0);
                    textOn = false;
                }
            }
            
        }
        
    }

    public void SetTimer(int m, int s)
    {
        if (s > 59)
            seconds = 59;
        else if (s < 0)
            seconds = 0;
        //minutes = m;
        //seconds = s;
        secondTimer = s;
        SetTimerText();
    }

    private void SetTimerText()
    {
        string secondsText = "" + seconds;
        if(seconds < 10)
        {
            secondsText = "0" + seconds;
        }
        timerText.text = minutes + ":" + secondsText;
    }
}
