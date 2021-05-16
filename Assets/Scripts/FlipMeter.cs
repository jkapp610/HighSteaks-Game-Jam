using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class FlipMeter : MonoBehaviour{

     public GameObject  flipMeter;
     public GameObject Bar;
    public ScoreController score;
     public float speed= 3.0f;
    public float changeTime = 3.0f;
    private float flipquality = 0;
    public float timer;
    private bool countdown;
    private bool canmove;
    private bool hasflipped;
     int direction =1;
     public GameObject mylevelTimer;
    public GameObject blackscreen;
    [SerializeField]
    private float transparencyCounter = 1f;
    private bool transparencyUp = true;
    private string sceneName;
    // Start is called before the first frame update
    void Start(){
        flipMeter.SetActive(false);
         timer = changeTime;
         countdown = false;
         canmove =false;
         hasflipped = false;
         Scene currentscene = SceneManager.GetActiveScene();
         string sceneName = currentscene.name;
        
       
    }

    // Update is called once per frame
    void Update(){
        /*
        if (Input.GetKeyDown(KeyCode.F)){
            flipMeter.SetActive(true);
            countdown = true;
            canmove= true;
            getflip = true;
            

            Debug.Log("F key was pressed.");
        }*/
        if(countdown){
            timer -= Time.deltaTime;
            if (timer < 0){
                direction = -direction;
                timer = changeTime;
            }
        }
        if(!hasflipped && mylevelTimer.GetComponent<LevelTimer>().minutes==0 && mylevelTimer.GetComponent<LevelTimer>().seconds==0){
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
            StartCoroutine("FlipAnimation");
            countdown = false;
            canmove = false;
            hasflipped = true;
            
        }
        if(transparencyCounter < 1f && transparencyUp)
        {
            transparencyCounter += Time.deltaTime;
            transparencyCounter = Mathf.Clamp(transparencyCounter, 0f, 1f);
            blackscreen.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, transparencyCounter);
        }
        else if (transparencyCounter > 0f && !transparencyUp)
        {
            transparencyCounter -= Time.deltaTime;
            transparencyCounter = Mathf.Clamp(transparencyCounter, 0f, 1f);
            blackscreen.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, transparencyCounter);
        }

        
    }
      void FixedUpdate(){
         if(canmove){
            Vector2 position = Bar.GetComponent<Rigidbody2D>().position;
            position.y = position.y + Time.deltaTime * speed * direction;
            Bar.GetComponent<Rigidbody2D>().MovePosition(position);
          }

    }

    private IEnumerator FlipAnimation()
    {
        if(sceneName=="Level1Pancakes"){
            transparencyCounter = 0f;
            transparencyUp = true;
            blackscreen.SetActive(true);
            GameObject pancake = GameObject.FindGameObjectWithTag("Pancake");
            pancake.GetComponent<PancakeObject>().StartFlip();
            mylevelTimer.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            transparencyUp = false;
            pancake.GetComponent<PancakeObject>().EndFlip(true);
            yield return new WaitForSeconds(1.5f);
            pancake.GetComponent<PancakeObject>().EndFlip(false);
            pancake.GetComponent<PancakeObject>().SetFlipEnding(flipquality);
            yield return new WaitForSeconds(2f);
            score.SetFlipQuality(flipquality);
        }
        if(sceneName=="Level2StirFry"){


        }
         if(sceneName=="Level3Steak"){


        }


    }
}
