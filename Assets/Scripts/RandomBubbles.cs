using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomBubbles : MonoBehaviour
{
    public static int numbubbles = 100;
    private GameObject[] circles = new GameObject[numbubbles];
    public float timer = 0f;
    public float interval = 2000f;
    private float timerscale = 0f;
    public int boarder = 23;
    public Sprite circleSprite;
    private int curr = 0;


    void Start()
    { 

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        Vector3 pos = new Vector3(-5, 0, 0);

        for (int i = 0; i < numbubbles; i++)
        {
            int randomX = Random.Range(-boarder, boarder);
            int randomY = Random.Range(-boarder, boarder);
            int randomScale = Random.Range(1, 6);
            //circles[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //In order to implement a sprite for this, I created a sprite object instead.
            circles[i] = new GameObject("New Sprite");
            SpriteRenderer newSpriteRender = circles[i].AddComponent<SpriteRenderer>();
            circles[i].SetActive(false);
            newSpriteRender.sprite = circleSprite;
            newSpriteRender.sortingOrder = 20; //Instead of moving the z position, we can set the sprite to display over the pan and pancake.
            newSpriteRender.color -= new Color(0f, 0f, 0f, .7f);
            circles[i].transform.position = new Vector3(randomX*0.07f, randomY*0.07f, 0);
            circles[i].transform.localScale += new Vector3(randomScale*0.01f, randomScale * 0.01f, 0);
            circles[i].name = "Circle_" + i;
            //pos.x++;
        }
    }

    void Update()
    {
        timer += Time.deltaTime*timerscale;
        Debug.Log(timer + " :timer");
        //Debug.Log(interval + " :interval");
        if (curr < numbubbles - 5)
        {
            curr += 5;
        }
        else
        {
            curr = 0;
        }
        if (timer >= interval)
        {
            for (int i = curr; i < curr+5; i++)
            {
                int randomValue = Random.Range(0, 2);
                if (randomValue != 0)
                {
                    circles[i].SetActive(true);
                    
                }
                //For non-persistent bubbles uncomment this line:
                //else circles[i].SetActive(false);  
            }
            timer = 0;
        }

    }

    public void SetTempViaZVal(float dialZVal)
    {

        timerscale = Mathf.Abs(dialZVal);
    }
}
