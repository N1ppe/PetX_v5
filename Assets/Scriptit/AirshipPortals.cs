using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirshipPortals : MonoBehaviour {

    public GameObject player, pet,questColObject;
    public GameObject TeleportLocation;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        pet = GameObject.FindWithTag("Pet");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(questColObject.GetComponent<quest>().questName == missionNames.Thunderstorm && questColObject.GetComponent<quest>().startedQuest == true)
            {
                player.transform.position = TeleportLocation.transform.position;
                pet.transform.position = TeleportLocation.transform.position;
            }
            else if (questColObject.GetComponent<quest>().questName == missionNames.BlackIce && questColObject.GetComponent<quest>().startedQuest == true)
            {
                player.transform.position = TeleportLocation.transform.position;
                pet.transform.position = TeleportLocation.transform.position;
            }
            else if (questColObject.GetComponent<quest>().questName == missionNames.IceFire && questColObject.GetComponent<quest>().startedQuest == true)
            {
                player.transform.position = TeleportLocation.transform.position;
                pet.transform.position = TeleportLocation.transform.position;
            }
        }
    }
}