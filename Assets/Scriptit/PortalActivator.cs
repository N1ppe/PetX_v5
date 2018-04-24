using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalActivator : MonoBehaviour {

    public thisPortalName ThisPortalName;
    public bool isActive = false;
    public GameObject player,Active;
    public SpriteRenderer InActive;
    public GameObject mapActive;
    public Image mapInActive;


	void Start () {
        player = GameObject.FindWithTag("Player");
    }
	
	void Update () {

        if (isActive)
        {
            InActive.enabled = false;
            Active.SetActive(true);

            mapInActive.enabled = false;
            mapActive.SetActive(true);
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isActive = true;

        if(ThisPortalName == thisPortalName.home)
        { player.GetComponent<playerButtonControl>().waypoints[0].unlocked = true; }
        if (ThisPortalName == thisPortalName.forest)
        { player.GetComponent<playerButtonControl>().waypoints[1].unlocked = true; }
        if (ThisPortalName == thisPortalName.towngym)
        { player.GetComponent<playerButtonControl>().waypoints[2].unlocked = true; }
        if (ThisPortalName == thisPortalName.earth)
        { player.GetComponent<playerButtonControl>().waypoints[3].unlocked = true; }
        if (ThisPortalName == thisPortalName.bazaar)
        { player.GetComponent<playerButtonControl>().waypoints[4].unlocked = true; }
        if (ThisPortalName == thisPortalName.wetlands)
        { player.GetComponent<playerButtonControl>().waypoints[5].unlocked = true; }
        if (ThisPortalName == thisPortalName.cave)
        { player.GetComponent<playerButtonControl>().waypoints[6].unlocked = true; }
        if (ThisPortalName == thisPortalName.summit)
        { player.GetComponent<playerButtonControl>().waypoints[7].unlocked = true; }
        if (ThisPortalName == thisPortalName.clouds)
        { player.GetComponent<playerButtonControl>().waypoints[8].unlocked = true; }
    }
}
public enum thisPortalName
{
    home,forest,towngym,earth,bazaar,wetlands,cave,summit,clouds
}
