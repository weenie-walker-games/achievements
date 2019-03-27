using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerFinish : MonoBehaviour
{

    public GameObject timerTrigger;         //used to store the trigger so we can set it active again to allow retries.
    
    void Start()
    {
       
    }


    private void OnEnable()
    {
        StartCoroutine(TimeAchieve());
    }

    private void OnTriggerEnter(Collider other)
    {
        GlobalAchievements.triggerAch03 = true;
        Destroy(timerTrigger);                      //Clean up the scene as this trigger is no longer necessary
        Destroy(gameObject);
    }

    IEnumerator TimeAchieve()
    {

        yield return new WaitForSeconds(5);


        //TWO OPTIONS FOR THIS ACHIEVEMENT
        //One time only
        //Destroy(gameObject);

        //Allow retries
        timerTrigger.SetActive(true);
        gameObject.SetActive(false);

    }
}
