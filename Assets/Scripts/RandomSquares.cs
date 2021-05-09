using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSquares : MonoBehaviour
{
    private GameObject[] circles = new GameObject[10];
    public float timer, interval = 2f;
    public Sprite circleSprite;

    void Start()
    {
        Vector3 pos = new Vector3(-5, 0, 0);

        for (int i = 0; i < 10; i++)
        {
            int randomX = Random.Range(-3, 3);
            int randomY = Random.Range(-3, 3);
            int randomScale = Random.Range(1, 6);
            //circles[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //In order to implement a sprite for this, I created a sprite object instead.
            circles[i] = new GameObject("New Sprite");
            SpriteRenderer newSpriteRender = circles[i].AddComponent<SpriteRenderer>();
            newSpriteRender.sprite = circleSprite;
            newSpriteRender.sortingOrder = 20; //Instead of moving the z position, we can set the sprite to display over the pan and pancake.
            circles[i].transform.position = new Vector3(randomX, randomY, 0);
            circles[i].transform.localScale += new Vector3(randomScale*0.01f, randomScale * 0.01f, 0);
            circles[i].name = "Circle_" + i;
            //pos.x++;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            for (int i = 0; i < 10; i++)
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
