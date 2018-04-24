using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class cheats : MonoBehaviour {

    public GameObject cheatUIpart,gm,player;
	void Start ()
    {
        gm = GameObject.FindGameObjectWithTag("GameManagementTag");
        player = GameObject.FindGameObjectWithTag("Player");
    }
	void Update ()
    {
        //if (cheatUIpart.activeInHierarchy == true)
        cheatbuttonCheck(); 

	}
    public void allPetsOpen()
    {
        for(int loopy = 0; loopy < gm.GetComponent<gamemanagement>().AllMonsters.Length; loopy++)
        {
            gm.GetComponent<gamemanagement>().AllMonsters[loopy].allowEvolution = true;
        }
    }
    public void openAllTeleports()
    {
        for (int loopyTp = 0; loopyTp < player.GetComponent<playerButtonControl>().waypoints.Length; loopyTp++)
        {
            player.GetComponent<playerButtonControl>().waypoints[loopyTp].unlocked = true;
            player.GetComponent<playerButtonControl>().waypoints[loopyTp].teleport.GetComponent<PortalActivator>().isActive = true;
        }
    }

    public void cheatbuttonCheck()
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            if (EventSystem.current.currentSelectedGameObject.name == "cheat1") { allPetsOpen(); EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text = "All pets in use"; }
            if (EventSystem.current.currentSelectedGameObject.name == "cheat2") { gm.GetComponent<gamemanagement>().money = 1000; }
            if (EventSystem.current.currentSelectedGameObject.name == "cheat3") { openAllTeleports(); EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text = "All waypoints open"; }
            if (EventSystem.current.currentSelectedGameObject.name == "cheat4") { }
            if (EventSystem.current.currentSelectedGameObject.name == "cheat5") { }
            if (EventSystem.current.currentSelectedGameObject.name == "cheat6") { }
            if (EventSystem.current.currentSelectedGameObject.name == "cheat7") { }
            if (EventSystem.current.currentSelectedGameObject.name == "cheat8") { }
            if (EventSystem.current.currentSelectedGameObject.name == "cheat9") { }
            if (EventSystem.current.currentSelectedGameObject.name == "cheat10") { }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            cheatUIpart.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            cheatUIpart.SetActive(false);
        }
    }
}
