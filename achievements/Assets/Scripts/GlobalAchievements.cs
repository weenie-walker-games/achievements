using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAchievements : MonoBehaviour
{

    /* NOTE:
     * This script is based on the tutorial series as written by Jimmy Vegas.  However, this is not a proper
     * way to write this kind of script.  Instead, achievements should be Scriptable Objects and added as
     * an array in this script, removing the need to have separate, duplicative code for each achievement.
     * 
     * At some point, this code will need to be refactored to be written properly.
     */


    //General Variables (related to all achievements)
    public GameObject achNote;      //Notification panel
    public AudioSource achSound;    //Sound to show achievement has been collected; not used in this repository due to licensing issues
    public bool achActive = false;  //Are we triggering an achievement now?
    public GameObject achTitle;
    public GameObject achDesc;


    //Achievement 01 Specific - Collectible
    public GameObject ach01Image;
    public static int ach01Count;       //A static variable used to keep track of how many have already been collected; linked to CollectCube.cs
    public int ach01Trigger = 5;        //How many items need to be collected to trigger the achievement?
    public int ach01Code;               //A random integer that can be saved to PlayerPrefs and used to show if an achievement has previously been obtained


    //Achievement 02 Specific - End Level
    public GameObject ach02Image;
    public static bool triggerAch02 = false;    //A static bool to trigger that this achievement has been obtained; linked to LevelFinish.cs
    public int ach02Code;                       //A random integer that can be saved to PlayerPrefs and used to show if an achievement has previously been obtained



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ach01Code = PlayerPrefs.GetInt("Ach01");
        ach02Code = PlayerPrefs.GetInt("Ach02");

        if (ach01Count == ach01Trigger && ach01Code != 12345)            //The code 12345 is just an integer used for comparison purposes rather than using an on/off style bool.
        {
            StartCoroutine(Trigger01Ach());
        }

        if (triggerAch02 == true && ach02Code != 12346)            //The code 12346 is just an integer used for comparison purposes rather than using an on/off style bool.
        {
            StartCoroutine(Trigger02Ach());
        }


    }


    IEnumerator Trigger01Ach()
    {
        achActive = true;
        ach01Code = 12345;                          //Set code to show this achievement has been obtained
        PlayerPrefs.SetInt("Ach01", ach01Code);
        //achSound.Play();                          //Once an audio file has been obtained, uncomment out this line to use
        ach01Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "COLLECTION!";
        achDesc.GetComponent<Text>().text = "Created a collection-based achievement!";
        achNote.SetActive(true);
        yield return new WaitForSeconds(7);

        //Resetting UI
        achNote.SetActive(false);
        ach01Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }


    IEnumerator Trigger02Ach()
    {
        achActive = true;
        ach02Code = 12346;                          //Set code to show this achievement has been obtained
        PlayerPrefs.SetInt("Ach02", ach01Code);
        //achSound.Play();                          //Once an audio file has been obtained, uncomment out this line to use
        ach02Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "COMPLETED!";
        achDesc.GetComponent<Text>().text = "You made a level complete achievement!";
        achNote.SetActive(true);
        yield return new WaitForSeconds(7);

        //Resetting UI
        achNote.SetActive(false);
        ach02Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }



    //Use this section to clear the PlayerPrefs

    [SerializeField]
    private string[] achievementArray;

    public void ClearPlayerPrefs()
    {
        foreach (var achievement in achievementArray)
        {
            PlayerPrefs.SetInt(achievement, 0);
        }
    }
}
