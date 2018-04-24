﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcColliderVersion : MonoBehaviour {

    public GameObject screenCanvas,player,huutomerkkiCanvas;
    public bool disableHuutomerkki,seenThisNpc = false;

    public string NPC_name;
    [TextArea(1, 15)]
    public string[] texts;

    void Start ()
    {
        player = GameObject.FindWithTag("Player");
    }
	void Update ()
    {
        if (disableHuutomerkki == false)
        {
            if (seenThisNpc == true)
            {
                huutomerkkiCanvas.SetActive(false);
            }
            else
            {
                huutomerkkiCanvas.SetActive(true);
            }
        }
        nextTextButton();
	}
    public void nextTextButton()
    {
        if (seenThisNpc == true && Input.GetButtonDown("interract"))
        {
            nextText();
        }
    }
    public void nextText()
    {
        for(int y = 0; y < texts.Length; y++)
        {
            if(screenCanvas.GetComponentInChildren<Text>().text == texts[y])
            {
                if (y < texts.Length && y != texts.Length - 1)
                {
                    screenCanvas.GetComponentInChildren<Text>().text = texts[y + 1];
                    return;
                }
                else
                {
                    //seenThisNpc = false;
                    screenCanvas.SetActive(false);
                    player.GetComponent<playerMovement>().enabled = true;
                    //screenCanvas.GetComponentInChildren<Text>().text = "";
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if(other.tag == "Player" && player.GetComponent<playerAttacking>().atkAllow == true && Input.GetButtonDown("interract"))
        {
            seenThisNpc = true;

            screenCanvas.SetActive(true);
            screenCanvas.GetComponentInChildren<Text>().text = texts[0];
        }
        */
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && player.GetComponent<playerAttacking>().atkAllow == true && Input.GetButtonDown("interract"))
        {
            StartCoroutine(delay()); //seenThisNpc = true;

            screenCanvas.SetActive(true);
            if (GetComponent<afterQuestSpeech>().enabled == false)
            {
                screenCanvas.GetComponentInChildren<Text>().text = texts[0];
                player.GetComponent<playerMovement>().enabled = false;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        //seenThisNpc = false;
        screenCanvas.SetActive(false);
        screenCanvas.GetComponentInChildren<Text>().text = "";

        if (seenThisNpc == true)
        {
            GetComponent<afterQuestSpeech>().enabled = true;
            //Destroy(this.GetComponent<npcColliderVersion>());
            this.enabled = false;
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.1f);
        seenThisNpc = true;
    }
}