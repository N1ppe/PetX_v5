using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanagement : MonoBehaviour {

    GameObject player;
    [Header("World")]
    public int day;
    [Range(0,1000)]
    public int money;
    [Range(0, 100)]
    public float mana;
    public Image uIStamina, uIMana,petUIimage;
    public Sprite lukkoImg;
    float manaCalculated,staminaCalculated;
    public Text cashText;
    [Range(0,24)]
    public int timeOfDay;
    public Sprite[] timeVisuals;
    public Image kello;
    public Text dayText;
    [Header("__________________________")]
    public Monsters Pet;
    public Items chosenItem;
    public ItemsInBackpackClass[] playersBackpack;
    [Header("__________________________")]
    //lists / arrays I dont fucking know
    [Range(1,20)]
    public int CurrentPetInt;
    public Monsters[] AllMonsters;
    //public Buffs[] buffs;
    public Items[] AllItems;
    public houses[] enterableBuildings;
    public tehtavat[] quests;
    public GameObject[] npcChars;
    [Header("__________________________")]
    public Image[] questUiSprites;
    public Text[] questLogTexts;//,logItemCheckTexts;
    public GameObject evolvingCanvas;
    public Image petImg, petNextEvolveImg,animation;
    public Text[] petStatText;
    public Text[] reppuText;
    public Image reppuItemImg;
    [Header("Main quest state")]
    [Range(0,9)]
    public int destroyedEnemyPortals=0;
    //--------------------------------------------------
    float timeOfTravel = 5;
    float currentTime = 0;
    float normalizedValue;
    public Vector3 startPosition, endPosition;
    public GameObject blockToMoveUp;
    IEnumerator LerpObject()
    {
        blockToMoveUp.GetComponent<RectTransform>().anchoredPosition = startPosition;
        blockToMoveUp.GetComponentInChildren<Text>().GetComponent<CanvasRenderer>().SetAlpha(1f);
        currentTime = 0;
        while (currentTime <= timeOfTravel)
        {
            currentTime += 2*Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel; // we normalize our time 

            blockToMoveUp.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(startPosition, endPosition, normalizedValue);
            blockToMoveUp.GetComponentInChildren<Text>().CrossFadeAlpha(0f,2.5f, false);
            yield return null;
        }
    }
    //--------------------------------------------------

    void Start () {
        player = GameObject.FindWithTag("Player");
        Pet = AllMonsters[0];
        //Cursor.visible = false;
        //StartCoroutine(evolutionUI());
        reppuVisuals();
        statPetEvolutions();
    }
    void Update ()
    {
        petChangingInRuntime();
        //statPetEvolutions();//----------------------------------hard code pakko---------------------------------
        for (int r = 0; r < AllMonsters.Length; r++)
        {
            if (AllMonsters[r].allowEvolution == true)
            {
                AllMonsters[r].inMonsterCatalog.sprite = AllMonsters[r].petVisual;
            }
            else if (AllMonsters[r].allowEvolution == false) { AllMonsters[r].inMonsterCatalog.sprite = lukkoImg; }
        }

        clockChanger();
        moneyCounter();
        staminaBar();
        manaBar();
        petStatsUI();
        mainQuestUpdater();
	}
    public void questInfoOperation()
    {
        blockToMoveUp.GetComponent<RectTransform>().anchoredPosition = startPosition;
        blockToMoveUp.GetComponentInChildren<Text>().text = "Quest advanced";
        StartCoroutine(LerpObject());
    }
    public void evolutionInfoOperation()
    {
        blockToMoveUp.GetComponent<RectTransform>().anchoredPosition = startPosition;
        blockToMoveUp.GetComponentInChildren<Text>().text = "New evolution achieved";
        StartCoroutine(LerpObject());
    }
    public void mainQuestUpdater()
    {
        switch (destroyedEnemyPortals)
        {
            case 1:
                questLogTexts[0].text = "Monster portals 1/9";
                break;
            case 2:
                questLogTexts[0].text = "Monster portals 2/9";
                break;
            case 3:
                questLogTexts[0].text = "Monster portals 3/9";
                break;
            case 4:
                questLogTexts[0].text = "Monster portals 4/9";
                break;
            case 5:
                questLogTexts[0].text = "Monster portals 5/9";
                break;
            case 6:
                questLogTexts[0].text = "Monster portals 6/9";
                break;
            case 7:
                questLogTexts[0].text = "Monster portals 7/9";
                break;
            case 8:
                questLogTexts[0].text = "Monster portals 8/9";
                break;
            case 9:
                questLogTexts[0].text = "Monster portals destroyed";
                break;
            default:
                questLogTexts[0].text = "Rid the world from monster portals 0/9";
                break;
        }
    }
    public void clockChanger()
    {
        dayText.text = day.ToString();
        if (timeOfDay < 12)
        {
            for (int t = 0; t < timeVisuals.Length; t++)
            {
                if (t == timeOfDay) { kello.sprite = timeVisuals[t]; }
            }
        }
        else if(timeOfDay >= 12)
        {
            if (timeOfDay == 12) { kello.sprite = timeVisuals[0]; }
            if (timeOfDay == 13) { kello.sprite = timeVisuals[1]; }
            if (timeOfDay == 14) { kello.sprite = timeVisuals[2]; }
            if (timeOfDay == 15) { kello.sprite = timeVisuals[3]; }
            if (timeOfDay == 16) { kello.sprite = timeVisuals[4]; }
            if (timeOfDay == 17) { kello.sprite = timeVisuals[5]; }
            if (timeOfDay == 18) { kello.sprite = timeVisuals[6]; }
            if (timeOfDay == 19) { kello.sprite = timeVisuals[7]; }
            if (timeOfDay == 20) { kello.sprite = timeVisuals[8]; }
            if (timeOfDay == 21) { kello.sprite = timeVisuals[9]; }
            if (timeOfDay == 22) { kello.sprite = timeVisuals[10]; }
            if (timeOfDay == 23) { kello.sprite = timeVisuals[11]; }
            if (timeOfDay == 24) { kello.sprite = timeVisuals[0]; }
        }
    }
    public void moneyCounter()
    {
        cashText.text = "Money: " + money;
    }
    public void manaBar()
    {
        manaCalculated = mana / 100f;
        uIMana.fillAmount = manaCalculated;
    }
    public void staminaBar()
    {
        staminaCalculated = player.GetComponent<playerMovement>().stamina / 100f;
        uIStamina.fillAmount =staminaCalculated;
    }
    public void petStatsUI()
    {
        petStatText[0].text ="AGI: " + Pet.agility;
        petStatText[1].text = "WIS: " + Pet.wisdom;
        petStatText[2].text = "STR: " + Pet.strength;
        petStatText[3].text = "LUK: " + Pet.luck;
    }
    public void currentPetAttackGain()
    {
        for (int i = 0; i < AllMonsters.Length; i++)
        {
            if (i == CurrentPetInt)
            {
               AllMonsters[i - 1].strength += 1;
            }
        }
    }
    public void sleepBehavior()
    {
        //do pet evolution scene
    }
    public void reppuVisuals()
    {
        for(int e = 0; e < AllItems.Length; e++)
        {
            for (int t = 0; t < playersBackpack.Length; t++)
            {
                if (playersBackpack[t].name == AllItems[e].name)
                {
                    // playersBackpack[t] = AllItems[e];
                    playersBackpack[t].name = AllItems[e].name;
                    playersBackpack[t].description = AllItems[e].description;
                    playersBackpack[t].amount = AllItems[e].amount;
                    playersBackpack[t].itemPropertyInt = AllItems[e].itemPropertyInt;
                    playersBackpack[t].sellCost = AllItems[e].sellCost;
                    playersBackpack[t].itemImage = AllItems[e].itemImage;
                }
            }
        }
        for(int r = 0; r < 10; r++)
        {
            reppuText[r].text = playersBackpack[r].name;
            reppuItemImg.sprite = playersBackpack[0].itemImage;
        }
    }
    public void petChangingInRuntime()
    {
        for (int r = 0; r < AllMonsters.Length; r++)
        {
            if (r == CurrentPetInt-1)
            {
                Pet = AllMonsters[r];
            }
        }
    }
    public void statPetEvolutions()//----------------------------------hard code what pet stat allows what next evolution----------------------------------
    {
        //Light T2 pets
        if (CurrentPetInt == 2) //Grass
        {
            //if (Pet.strength == 0 && Pet.agility == 0 && Pet.wisdom == 100 && Pet.luck == 0)
            if (Pet.wisdom >= 100)
            {
                AllMonsters[3].allowEvolution = true; if (AllMonsters[3].bringTextUI == false) { evolutionInfoOperation(); AllMonsters[3].bringTextUI = true; }
            }
        }
        if (CurrentPetInt == 2) //LightFire
        {
            if (Pet.strength >= 50 && Pet.wisdom >= 50)
            {
                AllMonsters[4].allowEvolution = true; if (AllMonsters[4].bringTextUI == false) { evolutionInfoOperation(); AllMonsters[4].bringTextUI = true; }
            }
        }
        if (CurrentPetInt == 2) //Water
        {
            if (Pet.agility >= 100)
            {
                AllMonsters[5].allowEvolution = true; if (AllMonsters[5].bringTextUI == false) { evolutionInfoOperation(); AllMonsters[5].bringTextUI = true; }
            }
        }
        if (CurrentPetInt == 2) //Air
        {
            if (Pet.agility >= 50 && Pet.luck >= 50)
            {
                AllMonsters[6].allowEvolution = true; if (AllMonsters[6].bringTextUI == false) { evolutionInfoOperation(); AllMonsters[6].bringTextUI = true; }
            }
        }

        //Light T3 pets
        if (CurrentPetInt == 6) //Pure Water
        {
            if (Pet.agility >= 300)
            {
                AllMonsters[13].allowEvolution = true; if (AllMonsters[13].bringTextUI == false) { evolutionInfoOperation(); AllMonsters[13].bringTextUI = true; }
            }
        }
        if (CurrentPetInt == 5 || CurrentPetInt == 7) //Holy
        {
            if(AllMonsters[4].allowEvolution == true && AllMonsters[6].allowEvolution == true)
            {
                if (Pet.wisdom >= 300)
                {
                    AllMonsters[14].allowEvolution = true; if (AllMonsters[14].bringTextUI == false) { evolutionInfoOperation(); AllMonsters[14].bringTextUI = true; }
                }
            }
        }
        //Dark T2 pets
        if (CurrentPetInt == 3) //Earth
        {
            if (Pet.strength >= 100)
            {
                AllMonsters[7].allowEvolution = true; if (AllMonsters[7].bringTextUI == false) { evolutionInfoOperation(); AllMonsters[7].bringTextUI = true; }
            }
        }
        if (CurrentPetInt == 3) //DarkFire
        {
            if (Pet.strength >= 50 && Pet.wisdom >= 50)
            {
                AllMonsters[8].allowEvolution = true; if (AllMonsters[8].bringTextUI == false) { evolutionInfoOperation(); AllMonsters[8].bringTextUI = true; }
            }
        }
        if (CurrentPetInt == 3) //Ice
        {
            if (Pet.agility >= 50 && Pet.wisdom >= 50)
            {
                AllMonsters[9].allowEvolution = true; if (AllMonsters[9].bringTextUI == false) { evolutionInfoOperation(); AllMonsters[9].bringTextUI = true; }
            }
        }
        if (CurrentPetInt == 3) //Electricity
        {
            if (Pet.luck >= 100)
            {
                AllMonsters[10].allowEvolution = true; if (AllMonsters[10].bringTextUI == false) { evolutionInfoOperation(); AllMonsters[10].bringTextUI = true; }
            }
        }

        //Dark T3 pets
        if (CurrentPetInt == 10) //Black Ice
        {
            if (Pet.agility >= 150 && Pet.wisdom >= 150)
            {
                AllMonsters[15].allowEvolution = true; if (AllMonsters[15].bringTextUI == false) { evolutionInfoOperation(); AllMonsters[15].bringTextUI = true; }
            }
        }
        if (CurrentPetInt ==  8) //Primal Earth
        {
            if (Pet.strength >= 300)
            {
                AllMonsters[16].allowEvolution = true; if (AllMonsters[16].bringTextUI == false) { evolutionInfoOperation(); AllMonsters[16].bringTextUI = true; }
            }
        }
        if (CurrentPetInt == 9 || CurrentPetInt == 10) //IceFire
        {
            if (AllMonsters[8].allowEvolution == true && AllMonsters[9].allowEvolution == true)
            {
                if (Pet.strength >= 150 && Pet.wisdom >= 150)
                {
                    AllMonsters[17].allowEvolution = true; if (AllMonsters[17].bringTextUI == false) { evolutionInfoOperation(); AllMonsters[17].bringTextUI = true; }
                }
            }
        }

        //Hybrid T3 pets
        if (CurrentPetInt == 4 || CurrentPetInt == 6 || CurrentPetInt == 8) //Gaia
        {
            if(AllMonsters[3].allowEvolution == true && AllMonsters[5].allowEvolution == true && AllMonsters[7].allowEvolution == true)
            {
                if (Pet.strength >= 100 && Pet.agility >= 100 && Pet.wisdom >= 100)
                {
                    AllMonsters[11].allowEvolution = true; if (AllMonsters[11].bringTextUI == false) { evolutionInfoOperation(); AllMonsters[11].bringTextUI = true; }
                }
            }
        }
        if (CurrentPetInt == 6 || CurrentPetInt == 7 || CurrentPetInt == 11) //Thunderstorm
        {
            if (AllMonsters[5].allowEvolution == true && AllMonsters[6].allowEvolution == true && AllMonsters[10].allowEvolution == true)
            {
                if (Pet.agility >= 150 && Pet.luck >= 150)
                {
                    AllMonsters[12].allowEvolution = true; if (AllMonsters[12].bringTextUI == false) { evolutionInfoOperation(); AllMonsters[12].bringTextUI = true; }
                }
            }
        }
        //T4 pets
        if (AllMonsters[1].allowEvolution == true && AllMonsters[3].allowEvolution == true &&AllMonsters[4].allowEvolution == true && AllMonsters[5].allowEvolution == true &&
            AllMonsters[6].allowEvolution == true && AllMonsters[13].allowEvolution == true && AllMonsters[14].allowEvolution == true && AllMonsters[11].allowEvolution == true) //Cosmic
        {
            if(CurrentPetInt == 2 || CurrentPetInt == 4 || CurrentPetInt == 5 || CurrentPetInt == 6 || CurrentPetInt == 7 || CurrentPetInt == 14 || CurrentPetInt == 15 || CurrentPetInt == 12)
            {
                if (Pet.agility >= 999 && Pet.luck >= 999 && Pet.strength >= 999 && Pet.wisdom >= 999)
                {
                    AllMonsters[18].allowEvolution = true; if (AllMonsters[18].bringTextUI == false) { evolutionInfoOperation(); AllMonsters[18].bringTextUI = true; }
                }
            }
        }
        if (AllMonsters[2].allowEvolution == true && AllMonsters[7].allowEvolution == true && AllMonsters[8].allowEvolution == true && AllMonsters[9].allowEvolution == true &&
            AllMonsters[10].allowEvolution == true && AllMonsters[15].allowEvolution == true && AllMonsters[16].allowEvolution == true && AllMonsters[17].allowEvolution == true && AllMonsters[12].allowEvolution == true) //Abyss
        {
            if (CurrentPetInt == 3 || CurrentPetInt == 8 || CurrentPetInt == 9 || CurrentPetInt == 10 || CurrentPetInt == 11 || CurrentPetInt == 16 || CurrentPetInt == 17 || CurrentPetInt == 18 || CurrentPetInt == 13)
            {
                if (Pet.agility >= 999 && Pet.luck >= 999 && Pet.strength >= 999 && Pet.wisdom >= 999)
                {
                    AllMonsters[19].allowEvolution = true; if (AllMonsters[19].bringTextUI == false) { evolutionInfoOperation(); AllMonsters[19].bringTextUI = true; }
                }
            }
        }
    }
    IEnumerator evolutionUI()
    {
        petImg.sprite = Pet.petVisual;
        //petNextEvolveImg = 
        petImg.GetComponent<Image>().enabled = true;

        evolvingCanvas.SetActive(true);
        animation.GetComponent<Image>().enabled = true;
        //play animation on top
        yield return new WaitForSeconds(1f);
        petImg.GetComponent<Image>().enabled = false;
        petNextEvolveImg.GetComponent<Image>().enabled = true;
        animation.GetComponent<Image>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        evolvingCanvas.SetActive(false);
    }
}
[System.Serializable]
public class Monsters
{
    public string name, description;
    public elements petElement;
    public int strength, agility, wisdom , luck;    //upgradable stats
    public int health, hunger, happiness, cleaniness;    //beauty
    public bool allowEvolution = false;
    public bool bringTextUI=false;
    public Sprite petVisual;
    public Image inMonsterCatalog;
    public GameObject petInWorldPrefab,petsAttack;
    public Animator petsAnimator;
}
[System.Serializable]
public class Buffs
{
    public string name, description;
    public int buffPropertyInt;
    public bool buffBool;
}
[System.Serializable]
public class ItemsInBackpackClass
{
    public string name, description;
    public int amount, itemPropertyInt, sellCost;
    public Sprite itemImage;
}
[System.Serializable]
public class Items
{
    public string name, description;
    public int amount,itemPropertyInt,sellCost;
    public Sprite itemImage;
}
[System.Serializable]
public class houses
{
    public string name;
    public int sceneIndex;
    public Vector3 locationOnMap,locationOnMapReturn;
}
[System.Serializable]
public class tehtavat
{
    public string questName;
    public tehtavatSubItem[] itemsToLookFor;
    public Sprite qSprt;

}
[System.Serializable]
public class tehtavatSubItem
{
    public string name;
    public int itemAmount, amountNeeded;
}
[System.Serializable]
public enum elements
{
    ZERO,light,dark,grass,lightfire,water,air,earth,darkFire,ice,electricity,gaia,thunderstorm,pureWater,holy,blackIce,primalEarth,iceFire,cosmic,abyss
}