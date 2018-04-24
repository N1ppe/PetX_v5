using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quest : MonoBehaviour
{
    [Header("TO GET TO NEXT TEXT, CALL  missionsUiUpdating();  ONCE")]
    public GameObject gm;
    public GameObject textPanel,npcToEnable;
    public bool startedQuest=false;
    public missionNames questName;

    public int missionAdvancement;
    [TextArea(1, 15)]
    public string[] logtexts;
    [Header("Quest Advancer")]
    public bool isQuestAdvancer = false;
    public GameObject parent;
    public int advCapInt = 0;
    bool clickCheck;

    //------special quest variables
    public bool icecrm, chocolat;
    int primalearthaddint,holyaddint;

    void Start ()
    {
        gm = GameObject.FindWithTag("GameManagementTag");
    }
	void Update ()
    {
        if (Input.GetButton("interract"))
        {
            clickCheck = true;
        }
        else { clickCheck = false; }

        //special quest, bought items

        //IceFire quest
        /*
        if (questName == missionNames.IceFire && startedQuest == true && (chocolat==false||icecrm==false))
        {
            for (int chokocream = 0; chokocream < gm.GetComponent<gamemanagement>().playersBackpack.Length; chokocream++)
            {
                if (gm.GetComponent<gamemanagement>().playersBackpack[chokocream].name == "Chocolate" || gm.GetComponent<gamemanagement>().playersBackpack[chokocream].name == "Icecream")
                {
                    //----------------------------------------
                    if (gm.GetComponent<gamemanagement>().playersBackpack[chokocream].name == "Chocolate") { chocolat = true; }
                    if (gm.GetComponent<gamemanagement>().playersBackpack[chokocream].name == "Icecream") { icecrm = true; }
                    //----------------------------------------
                }
            }
        }
        */
    }
    public void missionsUi()
    {
        //start text
        if (questName == missionNames.Gaia)
        {
            gm.GetComponent<gamemanagement>().questLogTexts[1].text = gm.GetComponent<gamemanagement>().quests[1].questName;
            gm.GetComponent<gamemanagement>().questUiSprites[1].sprite = gm.GetComponent<gamemanagement>().quests[1].qSprt;
        }
        if (questName == missionNames.Holy)
        {
            gm.GetComponent<gamemanagement>().questLogTexts[2].text = gm.GetComponent<gamemanagement>().quests[2].questName;
            gm.GetComponent<gamemanagement>().questUiSprites[2].sprite = gm.GetComponent<gamemanagement>().quests[2].qSprt;
        }
        if (questName == missionNames.PrimalWater)
        {
            gm.GetComponent<gamemanagement>().questLogTexts[3].text = gm.GetComponent<gamemanagement>().quests[3].questName;
            gm.GetComponent<gamemanagement>().questUiSprites[3].sprite = gm.GetComponent<gamemanagement>().quests[3].qSprt;
        }
        if (questName == missionNames.PrimalEarth)
        {
            gm.GetComponent<gamemanagement>().questLogTexts[4].text = gm.GetComponent<gamemanagement>().quests[4].questName;
            gm.GetComponent<gamemanagement>().questUiSprites[4].sprite = gm.GetComponent<gamemanagement>().quests[4].qSprt;
        }
        if (questName == missionNames.BlackIce)
        {
            gm.GetComponent<gamemanagement>().questLogTexts[5].text = gm.GetComponent<gamemanagement>().quests[5].questName;
            gm.GetComponent<gamemanagement>().questUiSprites[5].sprite = gm.GetComponent<gamemanagement>().quests[5].qSprt;
        }
        if (questName == missionNames.IceFire)
        {
            gm.GetComponent<gamemanagement>().questLogTexts[6].text = gm.GetComponent<gamemanagement>().quests[6].questName;
            gm.GetComponent<gamemanagement>().questUiSprites[6].sprite = gm.GetComponent<gamemanagement>().quests[6].qSprt;
        }
        if (questName == missionNames.Thunderstorm)
        {
            gm.GetComponent<gamemanagement>().questLogTexts[7].text = gm.GetComponent<gamemanagement>().quests[7].questName;
            gm.GetComponent<gamemanagement>().questUiSprites[7].sprite = gm.GetComponent<gamemanagement>().quests[7].qSprt;
        }
        /*
        string questNameCheck="";
        if (questName == missionNames.Gaia) { questNameCheck = gm.GetComponent<gamemanagement>().quests[0].questName; }
        if (questName == missionNames.Holy) { questNameCheck = questNameCheck = gm.GetComponent<gamemanagement>().quests[1].questName; }
        if (questName == missionNames.PrimalWater) { questNameCheck = questNameCheck = gm.GetComponent<gamemanagement>().quests[2].questName; }
        if (questName == missionNames.PrimalEarth) { questNameCheck = gm.GetComponent<gamemanagement>().quests[3].questName; }
        if (questName == missionNames.BlackIce) { questNameCheck = gm.GetComponent<gamemanagement>().quests[4].questName; }
        if (questName == missionNames.IceFire) { questNameCheck = gm.GetComponent<gamemanagement>().quests[5].questName; }
        if (questName == missionNames.Thunderstorm) { questNameCheck = gm.GetComponent<gamemanagement>().quests[6].questName; }

        for (int r = 0; r < gm.GetComponent<gamemanagement>().questLogTexts.Length;r++)
        {
            if (questNameCheck == gm.GetComponent<gamemanagement>().quests[r].questName)//from quests list
            {
                Debug.Log(gm.GetComponent<gamemanagement>().quests[r].questName);
                for (int rr = 0; rr < gm.GetComponent<gamemanagement>().questLogTexts.Length; rr++)
                {
                    if (gm.GetComponent<gamemanagement>().questLogTexts[rr].text == "")//to first empty text in UI
                    {
                        gm.GetComponent<gamemanagement>().questLogTexts[rr].text = questNameCheck;
                        return;
                    }
                }
            }
        }
        */
    }
    public void missionsUiUpdating()
    {
        string questNameCheck = "";
        if (questName == missionNames.Gaia) { questNameCheck = gm.GetComponent<gamemanagement>().quests[1].questName; }
        if (questName == missionNames.Holy) { questNameCheck = gm.GetComponent<gamemanagement>().quests[2].questName; }
        if (questName == missionNames.PrimalWater) { questNameCheck = gm.GetComponent<gamemanagement>().quests[3].questName; }
        if (questName == missionNames.PrimalEarth) { questNameCheck = gm.GetComponent<gamemanagement>().quests[4].questName; }
        if (questName == missionNames.BlackIce) { questNameCheck = gm.GetComponent<gamemanagement>().quests[5].questName; }
        if (questName == missionNames.IceFire) { questNameCheck = gm.GetComponent<gamemanagement>().quests[6].questName; }
        if (questName == missionNames.Thunderstorm) { questNameCheck = gm.GetComponent<gamemanagement>().quests[7].questName; }

        for (int r = 0; r < gm.GetComponent<gamemanagement>().questLogTexts.Length; r++)
        {
            if (questNameCheck == gm.GetComponent<gamemanagement>().quests[r].questName)//from quests list
            {
                for(int t=0;t< parent.GetComponent<quest>().logtexts.Length; t++)
                {
                    if (parent.GetComponent<quest>().missionAdvancement < parent.GetComponent<quest>().logtexts.Length)
                    {
                        gm.GetComponent<gamemanagement>().questLogTexts[r].text = parent.GetComponent<quest>().logtexts[parent.GetComponent<quest>().missionAdvancement];
                        parent.GetComponent<quest>().missionAdvancement = parent.GetComponent<quest>().missionAdvancement + 1;
                        gm.GetComponent<gamemanagement>().questInfoOperation();
                        return;
                    }
                }
            }
        }
    }
    public void missionsOperation()
    {
        switch (questName)
        {
            case missionNames.Gaia:
                if (parent.GetComponent<quest>().startedQuest==true && parent.GetComponent<quest>().missionAdvancement == 0 && advCapInt == 1)
                {
                    for (int e = 0; e < gm.GetComponent<gamemanagement>().playersBackpack.Length; e++)
                    {
                        if (gm.GetComponent<gamemanagement>().playersBackpack[e].name == "")
                        {
                            gm.GetComponent<gamemanagement>().playersBackpack[e].name = gm.GetComponent<gamemanagement>().AllItems[5].name;
                            gm.GetComponent<gamemanagement>().playersBackpack[e].description = gm.GetComponent<gamemanagement>().AllItems[5].description;
                            gm.GetComponent<gamemanagement>().playersBackpack[e].itemPropertyInt = gm.GetComponent<gamemanagement>().AllItems[5].itemPropertyInt;
                            gm.GetComponent<gamemanagement>().playersBackpack[e].sellCost = gm.GetComponent<gamemanagement>().AllItems[5].sellCost;
                            gm.GetComponent<gamemanagement>().playersBackpack[e].itemImage = gm.GetComponent<gamemanagement>().AllItems[5].itemImage;
                            missionsUiUpdating();
                            return;
                        }
                    }
                }
                else if (parent.GetComponent<quest>().missionAdvancement==1 && advCapInt == 2)
                {
                    for (int e = 0; e < gm.GetComponent<gamemanagement>().playersBackpack.Length; e++)
                    {
                        if (gm.GetComponent<gamemanagement>().playersBackpack[e].name == "Goblet")
                        {
                            gm.GetComponent<gamemanagement>().playersBackpack[e].name = gm.GetComponent<gamemanagement>().AllItems[6].name;
                            gm.GetComponent<gamemanagement>().playersBackpack[e].description = gm.GetComponent<gamemanagement>().AllItems[6].description;
                            gm.GetComponent<gamemanagement>().playersBackpack[e].itemPropertyInt = gm.GetComponent<gamemanagement>().AllItems[6].itemPropertyInt;
                            gm.GetComponent<gamemanagement>().playersBackpack[e].sellCost = gm.GetComponent<gamemanagement>().AllItems[6].sellCost;
                            gm.GetComponent<gamemanagement>().playersBackpack[e].itemImage = gm.GetComponent<gamemanagement>().AllItems[6].itemImage;
                            missionsUiUpdating();
                        }
                    }
                }
                else if (parent.GetComponent<quest>().missionAdvancement == 2 && advCapInt == 3)
                {
                    for (int et = 0; et < gm.GetComponent<gamemanagement>().playersBackpack.Length; et++)
                    {
                        if (gm.GetComponent<gamemanagement>().playersBackpack[et].name == "Goblet of water")
                        {
                            gm.GetComponent<gamemanagement>().playersBackpack[et].name = "";
                            gm.GetComponent<gamemanagement>().playersBackpack[et].description = "";
                            gm.GetComponent<gamemanagement>().playersBackpack[et].itemPropertyInt = 0;
                            gm.GetComponent<gamemanagement>().playersBackpack[et].sellCost = 0;
                            gm.GetComponent<gamemanagement>().playersBackpack[et].itemImage = null;
                            missionsUiUpdating();
                        }
                    }
                }
                break;
            case missionNames.Holy:
                /*
                if (advCapInt ==0 && parent.GetComponent<quest>().missionAdvancement == advCapInt-1)
                { missionsUiUpdating(); }
                else if(parent.GetComponent<quest>().missionAdvancement == advCapInt - 1 && advCapInt != 5)
                {
                    for (int e = 0; e < gm.GetComponent<gamemanagement>().playersBackpack.Length; e++)
                    {
                        if (gm.GetComponent<gamemanagement>().playersBackpack[e].name == "")
                        {
                            gm.GetComponent<gamemanagement>().playersBackpack[e].name = gm.GetComponent<gamemanagement>().AllItems[11].name;
                            gm.GetComponent<gamemanagement>().playersBackpack[e].description = gm.GetComponent<gamemanagement>().AllItems[11].description;
                            gm.GetComponent<gamemanagement>().playersBackpack[e].itemPropertyInt = gm.GetComponent<gamemanagement>().AllItems[11].itemPropertyInt;
                            gm.GetComponent<gamemanagement>().playersBackpack[e].sellCost = gm.GetComponent<gamemanagement>().AllItems[11].sellCost;
                            gm.GetComponent<gamemanagement>().playersBackpack[e].itemImage = gm.GetComponent<gamemanagement>().AllItems[11].itemImage;
                            missionsUiUpdating();
                            return;
                        }
                    }
                    missionsUiUpdating();
                }
                if (advCapInt == 5)
                {
                    for (int er = 0; er < gm.GetComponent<gamemanagement>().playersBackpack.Length; er++)
                    {
                        if (gm.GetComponent<gamemanagement>().playersBackpack[er].name == gm.GetComponent<gamemanagement>().AllItems[11].name)
                        {
                            gm.GetComponent<gamemanagement>().playersBackpack[er].name = "";
                            gm.GetComponent<gamemanagement>().playersBackpack[er].description = "";
                            gm.GetComponent<gamemanagement>().playersBackpack[er].itemPropertyInt = 0;
                            gm.GetComponent<gamemanagement>().playersBackpack[er].sellCost = 0;
                            gm.GetComponent<gamemanagement>().playersBackpack[er].itemImage = null;
                        }
                    }
                    missionsUiUpdating();
                }
                */
                break;
            case missionNames.PrimalWater:
                if (advCapInt == 1 && parent.GetComponent<quest>().missionAdvancement == advCapInt - 1 && advCapInt != 1)
                { missionsUiUpdating(); }
                else if (parent.GetComponent<quest>().missionAdvancement == advCapInt - 1 && advCapInt != 2)
                {
                    for (int e = 0; e < gm.GetComponent<gamemanagement>().playersBackpack.Length; e++)
                    {
                        if (gm.GetComponent<gamemanagement>().playersBackpack[e].name == "")
                        {
                            gm.GetComponent<gamemanagement>().playersBackpack[e].name = gm.GetComponent<gamemanagement>().AllItems[10].name;
                            gm.GetComponent<gamemanagement>().playersBackpack[e].description = gm.GetComponent<gamemanagement>().AllItems[10].description;
                            gm.GetComponent<gamemanagement>().playersBackpack[e].itemPropertyInt = gm.GetComponent<gamemanagement>().AllItems[10].itemPropertyInt;
                            gm.GetComponent<gamemanagement>().playersBackpack[e].sellCost = gm.GetComponent<gamemanagement>().AllItems[0].sellCost;
                            gm.GetComponent<gamemanagement>().playersBackpack[e].itemImage = gm.GetComponent<gamemanagement>().AllItems[10].itemImage;
                            missionsUiUpdating();
                            return;
                        }
                    }
                    missionsUiUpdating();
                }
                if (parent.GetComponent<quest>().missionAdvancement == advCapInt - 1 && advCapInt == 2)
                {
                    for (int er = 0; er < gm.GetComponent<gamemanagement>().playersBackpack.Length; er++)
                    {
                        if (gm.GetComponent<gamemanagement>().playersBackpack[er].name == gm.GetComponent<gamemanagement>().AllItems[10].name)
                        {
                            gm.GetComponent<gamemanagement>().playersBackpack[er].name = "";
                            gm.GetComponent<gamemanagement>().playersBackpack[er].description = "";
                            gm.GetComponent<gamemanagement>().playersBackpack[er].itemPropertyInt = 0;
                            gm.GetComponent<gamemanagement>().playersBackpack[er].sellCost = 0;
                            gm.GetComponent<gamemanagement>().playersBackpack[er].itemImage = null;
                        }
                    }
                    missionsUiUpdating();
                }
                break;
            case missionNames.PrimalEarth:
                if (parent.GetComponent<quest>().startedQuest == true && parent.GetComponent<quest>().missionAdvancement == 0 && advCapInt == 1)
                {
                    missionsUiUpdating();
                }
                else if (parent.GetComponent<quest>().missionAdvancement == 1 && advCapInt == 2)
                {
                    missionsUiUpdating();
                }
                else if (parent.GetComponent<quest>().missionAdvancement == 2 && advCapInt == 3)
                {
                    missionsUiUpdating();
                }
                else if (parent.GetComponent<quest>().missionAdvancement == 3 && advCapInt == 4)
                {
                    missionsUiUpdating();
                }
                break;
                /*
                    if (advCapInt <= 3 && parent.GetComponent<quest>().missionAdvancement == advCapInt - 1)
                    {
                        for (int e = 0; e < gm.GetComponent<gamemanagement>().playersBackpack.Length; e++)
                        {
                            if (gm.GetComponent<gamemanagement>().playersBackpack[e].name == "")
                            {
                                gm.GetComponent<gamemanagement>().playersBackpack[e].name = gm.GetComponent<gamemanagement>().AllItems[7].name;
                                gm.GetComponent<gamemanagement>().playersBackpack[e].description = gm.GetComponent<gamemanagement>().AllItems[7].description;
                                gm.GetComponent<gamemanagement>().playersBackpack[e].itemPropertyInt = gm.GetComponent<gamemanagement>().AllItems[7].itemPropertyInt;
                                gm.GetComponent<gamemanagement>().playersBackpack[e].sellCost = gm.GetComponent<gamemanagement>().AllItems[7].sellCost;
                                gm.GetComponent<gamemanagement>().playersBackpack[e].itemImage = gm.GetComponent<gamemanagement>().AllItems[7].itemImage;
                                missionsUiUpdating();
                                return;
                            }
                        }
                    }
                    else if (advCapInt == 4 && parent.GetComponent<quest>().missionAdvancement == advCapInt - 1)
                    {
                        for (int e = 0; e < gm.GetComponent<gamemanagement>().playersBackpack.Length; e++)
                        {
                            if (gm.GetComponent<gamemanagement>().playersBackpack[e].name == gm.GetComponent<gamemanagement>().AllItems[7].name)
                            {
                                gm.GetComponent<gamemanagement>().playersBackpack[e].name = "";
                                gm.GetComponent<gamemanagement>().playersBackpack[e].description = "";
                                gm.GetComponent<gamemanagement>().playersBackpack[e].itemPropertyInt = 0;
                                gm.GetComponent<gamemanagement>().playersBackpack[e].sellCost = 0;
                                gm.GetComponent<gamemanagement>().playersBackpack[e].itemImage = null;


                                //set the altar visible or do an anim or something like thats, something visual

                            }
                        }
                        missionsUiUpdating();
                    }
                    */
            case missionNames.BlackIce:
                if (parent.GetComponent<quest>().startedQuest == true && parent.GetComponent<quest>().missionAdvancement == 0 && advCapInt == 1)
                {
                    missionsUiUpdating();
                }
                else if (parent.GetComponent<quest>().missionAdvancement == 1 && advCapInt == 2)
                {
                    missionsUiUpdating();
                }
                else if (parent.GetComponent<quest>().missionAdvancement == 2 && advCapInt == 3)
                {
                    missionsUiUpdating();
                }
                break;

            case missionNames.IceFire:

                if (parent.GetComponent<quest>().startedQuest == true && parent.GetComponent<quest>().missionAdvancement == 0 && advCapInt == 1)
                {
                    missionsUiUpdating();
                }
                else if (parent.GetComponent<quest>().missionAdvancement == 1 && advCapInt == 2)
                {
                    missionsUiUpdating();
                }
                else if (parent.GetComponent<quest>().missionAdvancement == 2 && advCapInt == 3)
                {
                    missionsUiUpdating();
                }
                break;

            case missionNames.Thunderstorm:
                if (parent.GetComponent<quest>().startedQuest == true && parent.GetComponent<quest>().missionAdvancement == 0 && advCapInt == 1)
                {
                    missionsUiUpdating();
                }
                else if (parent.GetComponent<quest>().missionAdvancement == 1 && advCapInt == 2)
                {
                    missionsUiUpdating();
                }
                else if (parent.GetComponent<quest>().missionAdvancement == 2 && advCapInt == 3)
                {
                    missionsUiUpdating();
                }
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            for (int y = 0; y < gm.GetComponent<gamemanagement>().npcChars.Length; y++)
            {
                gm.GetComponent<gamemanagement>().npcChars[y].SetActive(false);
            }
            switch (questName)
            {
                case missionNames.Gaia:
                    npcToEnable = gm.GetComponent<gamemanagement>().npcChars[0];
                    break;
                case missionNames.Holy:
                    npcToEnable = gm.GetComponent<gamemanagement>().npcChars[1];


                    if (parent.GetComponent<quest>().startedQuest == true && startedQuest==false && advCapInt !=6)
                    {

                        parent.GetComponent<quest>().holyaddint++;
                        gm.GetComponent<gamemanagement>().questLogTexts[2].text = parent.GetComponent<quest>().logtexts[parent.GetComponent<quest>().holyaddint - 1];
                        gm.GetComponent<gamemanagement>().questInfoOperation();

                        if (isQuestAdvancer == true) { Destroy(this.gameObject); }
                        //startedQuest = true;
                    }
                    else if(parent.GetComponent<quest>().startedQuest == true && advCapInt == 6 && parent.GetComponent<quest>().holyaddint == 5)
                    {
                        gm.GetComponent<gamemanagement>().questLogTexts[2].text = parent.GetComponent<quest>().logtexts[5];
                    }


                    break;
                case missionNames.PrimalWater:
                    npcToEnable = gm.GetComponent<gamemanagement>().npcChars[2];
                    break;
                case missionNames.PrimalEarth:
                    npcToEnable = gm.GetComponent<gamemanagement>().npcChars[3];


                    if (parent.GetComponent<quest>().startedQuest == true && startedQuest == false && advCapInt != 4)
                    {
                        parent.GetComponent<quest>().primalearthaddint++;
                        gm.GetComponent<gamemanagement>().questLogTexts[4].text = parent.GetComponent<quest>().logtexts[parent.GetComponent<quest>().primalearthaddint - 1];
                        gm.GetComponent<gamemanagement>().questInfoOperation();

                        if (isQuestAdvancer == true) { Destroy(this.gameObject); }
                        //startedQuest = true;
                    }
                    else if (parent.GetComponent<quest>().startedQuest == true && advCapInt == 4 && parent.GetComponent<quest>().primalearthaddint==3)
                    {
                        gm.GetComponent<gamemanagement>().questLogTexts[4].text = parent.GetComponent<quest>().logtexts[3];
                        gm.GetComponent<gamemanagement>().questInfoOperation();
                    }


                    break;
                case missionNames.BlackIce:
                    npcToEnable = gm.GetComponent<gamemanagement>().npcChars[4];
                    break;
                case missionNames.Thunderstorm:
                    npcToEnable = gm.GetComponent<gamemanagement>().npcChars[5];
                    break;
                case missionNames.IceFire:
                    npcToEnable = gm.GetComponent<gamemanagement>().npcChars[6];

                    /*
                    if (isQuestAdvancer == true && parent.GetComponent<quest>().chocolat==true && parent.GetComponent<quest>().icecrm == true && advCapInt == 2)
                    {
                        for (int e = 0; e < gm.GetComponent<gamemanagement>().playersBackpack.Length; e++)
                        {
                            if (gm.GetComponent<gamemanagement>().playersBackpack[e].name == "Chocolate")
                            {
                                gm.GetComponent<gamemanagement>().playersBackpack[e].name = "";
                                gm.GetComponent<gamemanagement>().playersBackpack[e].description = "";
                                gm.GetComponent<gamemanagement>().playersBackpack[e].itemPropertyInt = 0;
                                gm.GetComponent<gamemanagement>().playersBackpack[e].sellCost = 0;
                                gm.GetComponent<gamemanagement>().playersBackpack[e].itemImage = null;
                                //missionsUiUpdating();
                            }
                        }
                        for (int er = 0; er < gm.GetComponent<gamemanagement>().playersBackpack.Length; er++)
                        {
                            if (gm.GetComponent<gamemanagement>().playersBackpack[er].name == "Icecream")
                            {
                                gm.GetComponent<gamemanagement>().playersBackpack[er].name = "";
                                gm.GetComponent<gamemanagement>().playersBackpack[er].description = "";
                                gm.GetComponent<gamemanagement>().playersBackpack[er].itemPropertyInt = 0;
                                gm.GetComponent<gamemanagement>().playersBackpack[er].sellCost = 0;
                                gm.GetComponent<gamemanagement>().playersBackpack[er].itemImage = null;
                                //missionsUiUpdating();
                            }
                        }  
                    }
                    */
                    break;
            }
            npcToEnable.SetActive(true);

            if (isQuestAdvancer == false && clickCheck==true)
            {
                if (startedQuest == false) { missionsUi(); }
                startedQuest = true;
                missionsOperation();
                textPanel.SetActive(true);
            }
            else if (isQuestAdvancer == true && startedQuest==true) { missionsOperation(); }
            else if (isQuestAdvancer == true && startedQuest == false) { return; }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (isQuestAdvancer == false && clickCheck == true)
            {
                if (startedQuest == false) { missionsUi(); }
                startedQuest = true;
                missionsOperation();
                textPanel.SetActive(true);
            }
            else if (isQuestAdvancer == true && startedQuest == false) { missionsOperation(); }
        }

        if (other.tag == "Player" && Input.GetButtonDown("interract"))
        {
            if (isQuestAdvancer == false && startedQuest==false)
            {
                textPanel.SetActive(true);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (isQuestAdvancer == false)
            {
                textPanel.SetActive(false);
            }
        }
    }
}
public enum missionNames
{
    Gaia,Holy,PrimalWater,PrimalEarth,BlackIce,IceFire,Thunderstorm
}
public enum missionType
{
    gatherItems,getToLocation
}