using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSquares : MonoBehaviour
{
    private GameObject[] circles = new GameObject[25];
    public float timer = 2f;
    public float interval = 0.2f;
    public int boarder = 23;
    public Sprite circleSprite;
    private int curr = 0;

    void Start()
    {
        Vector3 pos = new Vector3(-5, 0, 0);

        for (int i = 0; i < 25; i++)
        {
            int randomX = Random.Range(-boarder, boarder);
            int randomY = Random.Range(-boarder, boarder);
            int randomScale = Random.Range(1, 6);
            //circles[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //In order to implement a sprite for this, I created a sprite object instead.
            circles[i] = new GameObject("New Sprite");
            SpriteRenderer newSpriteRender = circles[i].AddComponent<SpriteRenderer>();
            newSpriteRender.sprite = circleSprite;
            newSpriteRender.sortingOrder = 20; //Instead of moving the z position, we can set the sprite to display over the pan and pancake.
            circles[i].transform.position = new Vector3(randomX*0.1f, randomY*0.1f, 0);
            circles[i].transform.localScale += new Vector3(randomScale*0.01f, randomScale * 0.01f, 0);
            circles[i].name = "Circle_" + i;
            circles[i].SetActive(false);
            //pos.x++;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (curr < 20)
            curr += 5;
        else
            curr = 0;
        if (timer >= interval)
        {
            for (int i = curr; i < curr+5; i++)
            {
                int randomValue = Random.Range(0, 2);
                if (randomValue == 0)
                {
                    circles[i].SetActive(false);
                }
                else circles[i].SetActive(true);
            }
            timer = 0;
        }
    }
}
