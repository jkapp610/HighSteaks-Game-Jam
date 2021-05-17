using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level4FlipMeter : MonoBehaviour
{


       public GameObject  flipMeter;
     public GameObject Bar;
    //public ScoreController score;
     public OvenPower power;
    //public GameObject blackscreen;
    public float speed= 3.0f;
    public float changeTime = 3.0f;
    private float flipquality = 0;
    public float timer;
    private bool countdown;
    private bool canmove;
    private bool hasflipped;
     int direction =1;
    private float transparencyCounter = 1f;
    private bool transparencyUp = true;
     
    // Start is called before the first frame update
    void Start()
    {
          flipMeter.SetActive(false);
         timer = changeTime;
         countdown = false;
         canmove =false;
          hasflipped = false;
    }

    // Update is called once per frame
    void Update(){


        if(countdown){
            timer -= Time.deltaTime;
            if (timer < 0){
                direction = -direction;
                timer = changeTime;
            }
        
        }
         if(!hasflipped &&( power.getlostpower()) && Input.GetKeyDown(KeyCode.O)){
             flipMeter.SetActive(true);
            countdown = true;
            canmove= true;

         }
         if (countdown && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("FLIP");
            if(direction == 1)
            {
                flipquality = timer;
            }
            else
            {
                flipquality = changeTime - timer;
            }
            //Need to store a value based upon the position of the bar
            //when left mouse is clicked.  
            //base upon values of timer and direction
            //score.SetFlipQuality(flipquality) ;
            //StartCoroutine("FlipAnimation");
            countdown = false;
            canmove = false;
            hasflipped = true;
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }



        }
        if(transparencyCounter < 1f && transparencyUp)
        {
            transparencyCounter += Time.deltaTime;
            transparencyCounter = Mathf.Clamp(transparencyCounter, 0f, 1f);
            //blackscreen.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, transparencyCounter);
        }
        else if (transparencyCounter > 0f && !transparencyUp)
        {
            transparencyCounter -= Time.deltaTime;
            transparencyCounter = Mathf.Clamp(transparencyCounter, 0f, 1f);
            //blackscreen.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, transparencyCounter);
        }

        
    }
      void FixedUpdate(){
         if(canmove){
            Vector2 position = Bar.GetComponent<Rigidbody2D>().position;
            position.y = position.y + Time.deltaTime * speed * direction;
            Bar.GetComponent<Rigidbody2D>().MovePosition(position);
          }

         

    }
      
      private IEnumerator FlipAnimation(){
           yield return new WaitForSeconds(1.5f);
          
      }
}
