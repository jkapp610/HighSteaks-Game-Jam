using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakeObject : MonoBehaviour
{
    [SerializeField]
    private ScoreController scoreboard;
    [SerializeField]
    private double currentTemp;
    private int cookingSidePhase = 0;
    public Sprite[] PancakePhases;
    [SerializeField]
    private Sprite currentPhase;

    public GameObject peekSide;
    public GameObject otherSide;
    public bool stillPouring = true;

    private bool isFlipping = false;
    private bool isFalling = false;
    private bool cookedSide = false;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreboard = GetComponentInParent<ScoreController>();
        currentPhase = PancakePhases[0];
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTemperature();
        
        if (isFlipping)
        {
            float flipAngle = 299f * Time.deltaTime;
            gameObject.transform.Rotate(flipAngle, 0f, 0f);
            transform.localScale = transform.localScale + (new Vector3(1f, 1f, 0f) * Time.deltaTime);
            
        }
        else if (isFalling)
        {
            float flipAngle = 299f * Time.deltaTime;
            gameObject.transform.Rotate(flipAngle, 0f, 0f);
            transform.localScale = transform.localScale - (new Vector3(1f, 1f, 0f) * Time.deltaTime);
        }
        float pancakeAngle = Mathf.Abs(transform.rotation.eulerAngles.x);
        
        if(transform.localRotation.eulerAngles.x > 85 && transform.localRotation.eulerAngles.x < 95)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = currentPhase;
        }
        if (transform.localRotation.eulerAngles.x > 265 && transform.localRotation.eulerAngles.x < 275)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = PancakePhases[0];
        }
    }

    private void UpdateTemperature()
    {
        currentTemp = scoreboard.GetCurrentCookDegree();
        if(currentTemp >= 5400 && currentTemp < 6000)
        {
            //Phase 1 (Slightly)
            currentPhase = PancakePhases[1];
        }
        else if (currentTemp >= 6000 && currentTemp < 6200)
        {
            //Phase 2 (Perfect)
            currentPhase = PancakePhases[2];
        }
        else if (currentTemp >= 6200 && currentTemp < 6800)
        {
            //Phase 3 (Darker)
            currentPhase = PancakePhases[3];
        }
        else if (currentTemp > 6800)
        {
            //Phase 4 (Burnt)
            currentPhase = PancakePhases[4];
        }
    }

    public void CheckPancake()
    {
        peekSide.transform.Rotate(10f, 0f, 0f);
        peekSide.GetComponent<SpriteRenderer>().color = new Color(.9f, .9f, .9f, 1f);
    }

    public void EndCheck()
    {
        peekSide.transform.Rotate(-10f, 0f, 0f);
        peekSide.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

    public void StartFlip()
    {
        peekSide.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        otherSide.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "blackscreen";
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        isFlipping = true;
    }

    public void EndFlip(bool on)
    {
        isFlipping = false;
        isFalling = on;
    }

    public bool GetIsFlipping()
    {
        return isFlipping;
    }

    public void SetFlipEnding(double flipscore)
    {
        gameObject.transform.localRotation = Quaternion.identity;
        if(flipscore > 1f)
        {
            peekSide.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            peekSide.transform.Rotate(70f, 0, 0);
            otherSide.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        }
    }
}
