using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableObject : MonoBehaviour
{
    public Sprite[] CookingPhases;
    [SerializeField]
    private Sprite currentPhase;
    //[SerializeField]
    private ScoreController scoreboard;
    [SerializeField]
    private bool isFlipping = false;
    [SerializeField]
    private bool isFalling = false;
    [SerializeField]
    double currentTemp;
    // Start is called before the first frame update
    void Start()
    {
        scoreboard = GetComponentInParent<ScoreController>();
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
    }

    private void UpdateTemperature()
    {
        
        currentTemp = scoreboard.GetCurrentCookDegree();
        if (currentTemp >= 8200 && currentTemp < 11500)
        {
            //Phase 1 (Perfect)
            currentPhase = CookingPhases[1];
        }
        else if (currentTemp >= 11500)
        {
            //Phase 2 (Burning)
            currentPhase = CookingPhases[2];
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = currentPhase;
    }

    public void StartFlip()
    {
        gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "blackscreen";
        isFlipping = true;
    }

    public void EndFlip(bool on)
    {
        isFlipping = false;
        isFalling = on;
    }

    public void SetFlipEnding(double flipscore)
    {
        if (flipscore > 1f)
        {
            GetComponent<Collider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().AddForce(transform.up * 5, ForceMode2D.Impulse);
        }
    }
}
