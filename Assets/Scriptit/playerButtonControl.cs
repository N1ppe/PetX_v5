using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class playerButtonControl : MonoBehaviour {

    public gamemanagement gm;
    [Range(0,4)]
    public int buttonInt=0;
    public GameObject evolves,reppu,quests,map,sleep,enemyportal;
    public Vector3 bedPosition;
    public openCanvas openWindow;
    public GameObject pet;
    [Range(0,11)]
    public int waypointIntToMoveTo;
    public mapWaypoints[] waypoints;
    public GameObject[] enemyPortals;
    [Header("enemy portal loot")]
    public GameObject lootPrefab;
    public string lootName;

    Animator animator;
    public EventSystem eventSystem;
    public Button b1, b2, b3, b4;

	void Start ()
    {
        pet = GameObject.FindWithTag("Pet");
        animator = this.GetComponent<Animator>();
    }
	void Update ()
    {
        playerOtherButtons();
        escaping();
        bb();
    }

    public void useItems()
    {
        /*
        for (int useitemlooper = 0; useitemlooper < gm.GetComponent<gamemanagement>().AllItems.Length; useitemlooper++)
        {
            if (gm.GetComponent<gamemanagement>().chosenItem.name == gm.GetComponent<gamemanagement>().AllItems[useitemlooper].name)
            {

            }
        }*/
        if (gm.GetComponent<gamemanagement>().chosenItem.name == "Goblet" || gm.GetComponent<gamemanagement>().chosenItem.name == "Goblet of water" || gm.GetComponent<gamemanagement>().chosenItem.name == "Flower")
        {
            return;
        }
        else
        {
            if (gm.GetComponent<gamemanagement>().chosenItem.name == "escape rope") { this.GetComponent<playerAttacking>().playerHealth = 0; }
            if (gm.GetComponent<gamemanagement>().chosenItem.name == "Baguette") { this.GetComponent<playerAttacking>().playerHealth = this.GetComponent<playerAttacking>().playerHealth + 25; }
            if (gm.GetComponent<gamemanagement>().chosenItem.name == "BaguetteDuFromage") { this.GetComponent<playerAttacking>().playerHealth = this.GetComponent<playerAttacking>().playerHealth + 40; }
            if (gm.GetComponent<gamemanagement>().chosenItem.name == "BaguetteDuFromageEtVin") { this.GetComponent<playerAttacking>().playerHealth = this.GetComponent<playerAttacking>().playerHealth + 65; }
            //EventSystem.current.currentSelectedGameObject.GetComponentInChildren(Text).text = "";

            for (int useitemlooper = 0; useitemlooper < gm.GetComponent<gamemanagement>().playersBackpack.Length; useitemlooper++)
            {
                if (gm.GetComponent<gamemanagement>().chosenItem.name == gm.GetComponent<gamemanagement>().playersBackpack[useitemlooper].name)
                {
                    gm.GetComponent<gamemanagement>().playersBackpack[useitemlooper].name = "";
                    return;
                }
            }
            for (int useitemlooper2 = 0; useitemlooper2 < gm.GetComponent<gamemanagement>().playersBackpack.Length; useitemlooper2++)
            {
                if (gm.GetComponent<gamemanagement>().playersBackpack[useitemlooper2].name == "")
                {
                    gm.GetComponent<gamemanagement>().reppuText[useitemlooper2].GetComponentInChildren<Text>().text = "";
                }
            }
            gm.GetComponent<gamemanagement>().chosenItem = null;
        }

    }

    public void destroyRightEnemySpawner()
    {
        for(int g = 0; g < enemyPortals.Length;g++)
        {
            if (gm.Pet.petElement == enemyPortals[g].GetComponent<destroySpawner>().portalsElement)
            {
                GameObject spawnedLoot = Instantiate(lootPrefab, enemyPortals[g].transform.position, Quaternion.identity);
                for (int u = 0; u < gm.GetComponent<gamemanagement>().AllItems.Length; u++)
                {
                    if (lootName == gm.GetComponent<gamemanagement>().AllItems[u].name)
                    {
                        spawnedLoot.name = gm.GetComponent<gamemanagement>().AllItems[u].name;
                        spawnedLoot.GetComponentInChildren<SpriteRenderer>().sprite = gm.GetComponent<gamemanagement>().AllItems[u].itemImage;
                    }
                }
                gm.GetComponent<gamemanagement>().destroyedEnemyPortals = gm.GetComponent<gamemanagement>().destroyedEnemyPortals + 1;
                gm.GetComponent<gamemanagement>().mainQuestUpdater();
                Destroy(enemyPortals[g]);
            }
        }
    }
    public void disableSpawnerUi()
    {
        enemyportal.active = false;
    }
    public void pb()
    {
        buttonInt = 1;
    }
    public void rb()
    {
        buttonInt = 2;
    }
    public void qb()
    {
        buttonInt = 3;
    }
    public void mb()
    {
        buttonInt = 4;
    }
    public void escaping()
    {
        if (Input.GetButtonDown("esc"))
        {
            evolves.SetActive(false);
            reppu.SetActive(false);
            quests.SetActive(false);
            map.SetActive(false);
            Time.timeScale = 1;
            openWindow = openCanvas.NONE;
            buttonInt = 0;
        }
    }
    public void playerOtherButtons()
    {
        //---------------------------------------------------------------------------------
        if (buttonInt == 1)
        {
            if (evolves.activeSelf == false)
            {
                evolves.SetActive(true);
                reppu.SetActive(false);
                quests.SetActive(false);
                map.SetActive(false);
                Time.timeScale = 1;
                openWindow = openCanvas.evolutions;
            }
            else
            {
                evolves.SetActive(false);
                reppu.SetActive(false);
                quests.SetActive(false);
                map.SetActive(false);
                Time.timeScale = 1;
                openWindow = openCanvas.NONE;
            }
        }
        else if (buttonInt == 2)
        {
            if (reppu.activeSelf == false)
            {
                gm.GetComponent<gamemanagement>().reppuVisuals();
                evolves.SetActive(false);
                reppu.SetActive(true);
                quests.SetActive(false);
                map.SetActive(false);
                Time.timeScale = 1;
                openWindow = openCanvas.reppu;
            }
            else
            {
                evolves.SetActive(false);
                reppu.SetActive(false);
                quests.SetActive(false);
                map.SetActive(false);
                Time.timeScale = 1;
                openWindow = openCanvas.NONE;
            }
        }
        else if (buttonInt == 3)
        {
            if (quests.activeSelf == false)
            {
                evolves.SetActive(false);
                reppu.SetActive(false);
                quests.SetActive(true);
                map.SetActive(false);
                Time.timeScale = 1;
                openWindow = openCanvas.quests;
            }
            else
            {
                evolves.SetActive(false);
                reppu.SetActive(false);
                quests.SetActive(false);
                map.SetActive(false);
                Time.timeScale = 1;
                openWindow = openCanvas.NONE;
            }
        }
        else if (buttonInt == 4)
        {
            if (map.activeSelf == false)
            {
                evolves.SetActive(false);
                reppu.SetActive(false);
                quests.SetActive(false);
                map.SetActive(true);
                Time.timeScale = 1;
                openWindow = openCanvas.map;
            }
            else
            {
                evolves.SetActive(false);
                reppu.SetActive(false);
                quests.SetActive(false);
                map.SetActive(false);
                Time.timeScale = 1;
                openWindow = openCanvas.NONE;
            }
        }

        buttonInt = 0;
        //---------------------------------------------------------------------------------
        if (Input.GetButtonDown("evolutions"))
        {
            if (openWindow == openCanvas.evolutions)
            {
                evolves.SetActive(false);
                Time.timeScale = 1;
                openWindow = openCanvas.NONE;
            }
            else
            {
                evolves.SetActive(true);
                reppu.SetActive(false);
                quests.SetActive(false);
                map.SetActive(false);
                Time.timeScale = 1;
                openWindow = openCanvas.evolutions;
            }
        }
        else if (Input.GetButtonDown("reppu"))
        {
            if (openWindow == openCanvas.reppu)
            {
                reppu.SetActive(false);
                Time.timeScale = 1;
                openWindow = openCanvas.NONE;
            }
            else
            {
                evolves.SetActive(false);
                reppu.SetActive(true);
                quests.SetActive(false);
                map.SetActive(false);
                Time.timeScale = 1;
                openWindow = openCanvas.reppu;
            }
        }
        else if (Input.GetButtonDown("quests"))
        {
            if (openWindow == openCanvas.quests)
            {
                quests.SetActive(false);
                Time.timeScale = 1;
                openWindow = openCanvas.NONE;
            }
            else
            {
                evolves.SetActive(false);
                reppu.SetActive(false);
                quests.SetActive(true);
                map.SetActive(false);
                Time.timeScale = 1;
                openWindow = openCanvas.quests;
            }
        }
        else if (Input.GetButtonDown("map"))
        {
            if (openWindow == openCanvas.map)
            {
                map.SetActive(false);
                Time.timeScale = 1;
                openWindow = openCanvas.NONE;
            }
            else
            {
                evolves.SetActive(false);
                reppu.SetActive(false);
                quests.SetActive(false);
                map.SetActive(true);
                Time.timeScale = 1;
                openWindow = openCanvas.map;
            }
        }
    }
    public void bb()
    {
        if(EventSystem.current.currentSelectedGameObject != null)
        {
            for (int g = 0; g < 10; g++)
            {
                if (EventSystem.current.currentSelectedGameObject.name == "b"+g.ToString())
                {
                    //gm.chosenItem = gm.playersBackpack[g-1];
                    gm.chosenItem.name = gm.playersBackpack[g - 1].name;
                    gm.chosenItem.description = gm.playersBackpack[g - 1].description;
                    gm.chosenItem.amount = gm.playersBackpack[g - 1].amount;
                    gm.chosenItem.itemPropertyInt = gm.playersBackpack[g - 1].itemPropertyInt;
                    gm.chosenItem.sellCost = gm.playersBackpack[g - 1].sellCost;
                    gm.chosenItem.itemImage = gm.playersBackpack[g - 1].itemImage;

                    gm.GetComponent<gamemanagement>().reppuItemImg.sprite = gm.playersBackpack[g - 1].itemImage;
                }
            }
        }
    }
    public void MonsterCatalog()
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            /*
            for (int u = 0; u < gm.GetComponent<gamemanagement>().AllMonsters.Length; u++)
            {
                if(gm.GetComponent<gamemanagement>().AllMonsters[u].petInWorldPrefab != null)
                {
                    gm.GetComponent<gamemanagement>().AllMonsters[u].petInWorldPrefab.SetActive(false);//disables all
                }
            }    
            */
            for (int g = 0; g < gm.GetComponent<gamemanagement>().AllMonsters.Length; g++)
            {
                if (EventSystem.current.currentSelectedGameObject.name == gm.GetComponent<gamemanagement>().AllMonsters[g].name && gm.GetComponent<gamemanagement>().AllMonsters[g].allowEvolution==true)
                {
                    //gm.GetComponent<gamemanagement>().Pet = gm.GetComponent<gamemanagement>().AllMonsters[g]; //this should work, but it doesnt workaround under
                    gm.GetComponent<gamemanagement>().CurrentPetInt = g+1;
                    gm.GetComponent<gamemanagement>().petUIimage.sprite = gm.GetComponent<gamemanagement>().AllMonsters[g].petVisual;
                    gm.GetComponent<gamemanagement>().AllMonsters[g].petInWorldPrefab.SetActive(true);
                    gm.GetComponent<gamemanagement>().AllMonsters[g].petsAttack.SetActive(true);
                    gm.GetComponent<gamemanagement>().AllMonsters[g].petsAttack.SetActive(false);
                    pet.GetComponent<petBehaviour>().animator = gm.GetComponent<gamemanagement>().AllMonsters[g].petsAnimator;

                    for (int u = 0; u < gm.GetComponent<gamemanagement>().AllMonsters.Length; u++)
                    {
                        if (gm.GetComponent<gamemanagement>().AllMonsters[u].petInWorldPrefab != null)
                        {
                            if (gm.GetComponent<gamemanagement>().AllMonsters[u] != gm.GetComponent<gamemanagement>().AllMonsters[g])
                            { gm.GetComponent<gamemanagement>().AllMonsters[u].petInWorldPrefab.SetActive(false); }
                        }
                    }
                }
            }
            eventSystem.SetSelectedGameObject(null);
        }
    }
    #region mapButtons
    public void mapW1() { waypointIntToMoveTo = 1; waypointTp(); }
    public void mapW2() { waypointIntToMoveTo = 2; waypointTp(); }
    public void mapW3() { waypointIntToMoveTo = 3; waypointTp(); }
    public void mapW4() { waypointIntToMoveTo = 4; waypointTp(); }
    public void mapW5() { waypointIntToMoveTo = 5; waypointTp(); }
    public void mapW6() { waypointIntToMoveTo = 6; waypointTp(); }
    public void mapW7() { waypointIntToMoveTo = 7; waypointTp(); }
    public void mapW8() { waypointIntToMoveTo = 8; waypointTp(); }
    public void mapW9() { waypointIntToMoveTo = 9; waypointTp(); }
    public void mapW10() { waypointIntToMoveTo = 10; waypointTp(); }
#endregion
    public void waypointTp()
    {
        for(int p = 1; p < 11; p++)
        {
            if (p == waypointIntToMoveTo)
            {
                if(waypoints[p - 1].unlocked == true)
                {
                    this.gameObject.transform.position = waypoints[p - 1].loc;
                    pet.gameObject.transform.position = waypoints[p - 1].loc;
                }
            }
        }
        waypointIntToMoveTo = 0;
    }
    public void sleepButton()
    {
        this.gameObject.transform.position = bedPosition;
        pet.gameObject.transform.position = bedPosition;
        animator.SetFloat("LastMoveY", -1f);
        sleep.gameObject.SetActive(false);
        gm.GetComponent<gamemanagement>().day++;
        gm.GetComponent<gamemanagement>().timeOfDay = 10;
        Time.timeScale = 1;
    }
    public void exitSleepWindow() { sleep.gameObject.SetActive(false); Time.timeScale = 1; }
#region selectPetButtons
    public void m1() { gm.GetComponent<gamemanagement>().CurrentPetInt = 1; }
    public void m2() { gm.GetComponent<gamemanagement>().CurrentPetInt = 2; }
    public void m3() { gm.GetComponent<gamemanagement>().CurrentPetInt = 3; }
    public void m4() { gm.GetComponent<gamemanagement>().CurrentPetInt = 4; }
    public void m5() { gm.GetComponent<gamemanagement>().CurrentPetInt = 5; }

    public void m6() { gm.GetComponent<gamemanagement>().CurrentPetInt = 6; }
    public void m7() { gm.GetComponent<gamemanagement>().CurrentPetInt = 7; }
    public void m8() { gm.GetComponent<gamemanagement>().CurrentPetInt = 8; }
    public void m9() { gm.GetComponent<gamemanagement>().CurrentPetInt = 9; }
    public void m10() { gm.GetComponent<gamemanagement>().CurrentPetInt = 10; }

    public void m11() { gm.GetComponent<gamemanagement>().CurrentPetInt = 11; }
    public void m12() { gm.GetComponent<gamemanagement>().CurrentPetInt = 12; }
    public void m13() { gm.GetComponent<gamemanagement>().CurrentPetInt = 13; }
    public void m14() { gm.GetComponent<gamemanagement>().CurrentPetInt = 14; }
    public void m15() { gm.GetComponent<gamemanagement>().CurrentPetInt = 15; }

    public void m16() { gm.GetComponent<gamemanagement>().CurrentPetInt = 16; }
    public void m17() { gm.GetComponent<gamemanagement>().CurrentPetInt = 17; }
    public void m18() { gm.GetComponent<gamemanagement>().CurrentPetInt = 18; }
    public void m19() { gm.GetComponent<gamemanagement>().CurrentPetInt = 19; }
    public void m20() { gm.GetComponent<gamemanagement>().CurrentPetInt = 20; }
    #endregion
}
[System.Serializable]
public class mapWaypoints
    {
    public string locationName;
    public bool unlocked = false;
    public Vector3 loc;
    public GameObject teleport;
    }
public enum openCanvas
{
NONE,evolutions,quests,reppu,map
}