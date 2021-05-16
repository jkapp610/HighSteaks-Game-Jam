using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenPower : MonoBehaviour
{
    public GameObject poweredDoor;
    public GameObject unpoweredDoor;
    public Level4timer timer;
    public GameObject BlackOverlay;
    [SerializeField]
    private bool isPowered = true;
    private bool lostpower = false;

    // Start is called before the first frame update
    void Start()
    {
        //LosePower();
        StartCoroutine("DelayedPowerOff");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DelayedPowerOff()
    {
        yield return new WaitForSeconds(5f);
        LosePower();
        yield return new WaitForSeconds(3f);
        RegainPower();
    }

    public void LosePower()
    {
        isPowered = false;
        lostpower=true;
        poweredDoor.SetActive(false);
        unpoweredDoor.SetActive(true);
        BlackOverlay.SetActive(true);
        //timer.SetTimer(0, 0);
        timer.gameObject.SetActive(false);
    }

    public void RegainPower()
    {
        isPowered = true;
        poweredDoor.SetActive(true);
        unpoweredDoor.SetActive(false);
        BlackOverlay.SetActive(false);
        timer.gameObject.SetActive(true);
    }
    public bool getlostpower(){
        return lostpower;
    }
}
