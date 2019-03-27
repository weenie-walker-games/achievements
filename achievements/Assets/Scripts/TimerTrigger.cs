using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{

    public GameObject finalTimeTrigger;

    private void OnTriggerEnter(Collider other)
    {
        finalTimeTrigger.SetActive(true);
        gameObject.SetActive(false);
    }


}
