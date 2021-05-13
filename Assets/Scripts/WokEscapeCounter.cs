using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WokEscapeCounter : MonoBehaviour
{
    public int maxEscapes;
    public int escapeCounter;
    GameObject currentVeggie;
    List<GameObject> veggies = new List<GameObject>(); //empty arraylist so a single veggie can not count twice
    // Start is called before the first frame update
    void Start()
    {
        escapeCounter = 0;
        veggies.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if (escapeCounter >= maxEscapes) {
            Debug.Log("Don't shake quite so vigorously");
        }
        //foreach(GameObject v in veggies) {
        //    Debug.Log(v.name);
        //}
    }

    private void OnTriggerEnter2D(Collider2D veggieCollider) {
        //Debug.Log("collided with trigger");
        currentVeggie = veggieCollider.gameObject;
        if (!veggies.Contains(currentVeggie)) {
            escapeCounter++;
            veggies.Add(currentVeggie);
        }
    }
}
