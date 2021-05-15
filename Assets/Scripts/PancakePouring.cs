using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakePouring : MonoBehaviour
{
    public Sprite freshPancake;
    public GameObject PancakePrefab;
    public GameObject levelHUD;
    public Sprite columnSprite;
    //Currently these variables can be seen, but you can only set them when you call the function Pour().
    //startingPos will be the vector3 in the scene that the pancake will spread out from.
    [SerializeField]
    Vector3 startingPos;
    //pourTime will be a float used to determine how long it takes to pour a pancake.
    //pancakeSize will hold the value for the maximum x or y value for the pancake's transform.scale
    [SerializeField]
    float timePassed, pourTime, pancakeSize;

    private bool isPouring;
    private GameObject newPancake;
    private GameObject pouringColumn;
    private float timeRatio;

    // Start is called before the first frame update
    void Start()
    {
        Pour(new Vector3(0f, 0f, 0f), 3f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isPouring)
        {
            timePassed += Time.deltaTime;
            timeRatio = timePassed / pourTime;
            newPancake.transform.localScale = new Vector3(1f, 1f, 1f) * pancakeSize * (timeRatio);
            if(timeRatio >= .8f)
            {
                //pouringColumn.transform.localScale = new Vector3(0.1f, 5f - (5f * pourTime/timePassed), 1f);
                Destroy(pouringColumn);
                //pouringColumn.transform.position = new Vector3(columnPosition.x, columnPosition.y * 1 / timeRatio, columnPosition.z);
            }
            if(timePassed >= pourTime)
            {
                //Destroy(pouringColumn);
                isPouring = false;
            }
        }
    }

    public void Pour(Vector3 origin, float duration, float size)
    {
        timePassed = 0f;
        
        //newPancake = new GameObject("Pancake");
        newPancake = Instantiate(PancakePrefab, origin, Quaternion.identity);
        newPancake.transform.SetParent(levelHUD.transform, true);
        newPancake.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        newPancake.transform.position = origin;
        //SpriteRenderer newPancakeSprite = newPancake.AddComponent<SpriteRenderer>();
        //newPancakeSprite.sprite = freshPancake;
        //newPancakeSprite.sortingOrder = 15;
        


        pouringColumn = new GameObject("PancakeFall");
        pouringColumn.transform.localScale = new Vector3(0.1f, 5f, 1f);
        pouringColumn.transform.position = origin + new Vector3(0f, 2.5f, 0f);
        SpriteRenderer newColumnSprite = pouringColumn.AddComponent<SpriteRenderer>();
        newColumnSprite.color = new Color(1f, 0.8941f, 0.6313f);
        newColumnSprite.sprite = columnSprite;
        newColumnSprite.sortingOrder = 16;

        pourTime = duration;
        pancakeSize = size;
        isPouring = true;
        
    }
}
