using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveFlame : MonoBehaviour
{
    //float maxDial = 10f;
    [SerializeField]
    private Transform[] flameSprites;
    [SerializeField]
    private float flickerTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        flameSprites = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        flickerTimer += Time.deltaTime;
        if(transform.localScale.x >= 0.8f && flickerTimer > 0.2f)
        {
            flickerTimer = 0f;
            float newModifier = Random.Range(.85f, 1f);
            for(int i = 1; i < flameSprites.Length; i++)
            {
                flameSprites[i].localScale = new Vector3(newModifier, newModifier, 1f);
            }
        }
    }

    public void SetFlameViaZVal(float dialZVal)
    {
        transform.localScale = new Vector3(1f, 1f, 1f) * (-1f * dialZVal);
    }
}
