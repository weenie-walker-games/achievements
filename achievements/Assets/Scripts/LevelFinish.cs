using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    public GameObject fadeOut;

    public GameObject thePlayer;            //Adding this code to prevent the player from moving

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(EndLevel());
    }

    IEnumerator EndLevel()
    {
        thePlayer.GetComponent<CharControl>().enabled = false;  //This line of code will prevent the player from moving during the fadeOut
        fadeOut.SetActive(true);
        fadeOut.GetComponent<Animation>().Play("FadeOut");
        yield return new WaitForSeconds(3.5f);
        GlobalAchievements.triggerAch02 = true;

        //Reset everything; this code may be adjusted if we were to jump to a new scene
        thePlayer.GetComponent<CharControl>().enabled = true;   //Reset player movement; 
        fadeOut.SetActive(false);
    }

}
