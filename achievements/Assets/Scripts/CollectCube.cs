using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCube : MonoBehaviour
{

    public AudioSource collectSound;        //used to indicate the item has been collected


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Collided");
            GlobalAchievements.ach01Count += 1;
            //collectSound.Play();                  //play the sound when a source file is obtained with proper licensing
            Destroy(gameObject);
        }

    }

}
