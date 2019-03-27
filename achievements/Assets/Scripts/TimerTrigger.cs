using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{

    public GameObject finalTimeTrigger;


    [SerializeField] Transform[] spawnPoints;

    private void OnEnable()
    {


    }

    private void OnTriggerEnter(Collider other)
    {

        //Randomize where the finalTimeTrigger object spawns
        int spawnLocationNumber = Random.Range(0, spawnPoints.Length);
        finalTimeTrigger.transform.position = spawnPoints[spawnLocationNumber].position;

        finalTimeTrigger.SetActive(true);
        gameObject.SetActive(false);
    }


}
