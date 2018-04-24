using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class houseSceneVersion : MonoBehaviour {

    public GameObject gm;
    public int houseNroIndex;
    public bool Inside = false;
    [Header("Furniture")]
    public FurnitureType furnitureType;
    public GameObject player,pet;

	void Start ()
    {
        player = GameObject.FindWithTag("Player");
        pet = GameObject.FindWithTag("Pet");
    }
	void Update ()
    {
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && furnitureType == FurnitureType.NA)
        {
            for(int i = 0; i < gm.GetComponent<gamemanagement>().enterableBuildings.Length; i++)
            {
                if(houseNroIndex == gm.GetComponent<gamemanagement>().enterableBuildings[i].sceneIndex)
                {
                    if (Inside == true)
                    {
                        other.transform.position = gm.GetComponent<gamemanagement>().enterableBuildings[i].locationOnMapReturn;
                        pet.transform.position = gm.GetComponent<gamemanagement>().enterableBuildings[i].locationOnMapReturn;
                        return;
                    }
                    else if (Inside == false)
                    {
                        other.transform.position = gm.GetComponent<gamemanagement>().enterableBuildings[i].locationOnMap;
                        pet.transform.position = gm.GetComponent<gamemanagement>().enterableBuildings[i].locationOnMap;
                        return;
                    }

                }
            }
        }
        if (other.gameObject.tag == "Player" && furnitureType == FurnitureType.bed)
        {
            player.GetComponent<playerButtonControl>().sleep.gameObject.SetActive(true);
            player.GetComponent<playerButtonControl>().bedPosition = this.gameObject.transform.position;
            player.GetComponent<playerAttacking>().playerHealth = Mathf.RoundToInt(player.GetComponent<playerAttacking>().hpMax);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        player.GetComponent<playerButtonControl>().sleep.gameObject.SetActive(false);
    }
}
public enum FurnitureType
{
    NA,bed,chair,closet
}