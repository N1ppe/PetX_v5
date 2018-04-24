using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class afterQuestSpeech : MonoBehaviour {
    public GameObject screenCanvas, player;

    [TextArea(1, 15)]
    public string[] texts;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        if (Input.GetButtonDown("interract"))
        {
            nextTextEnd();
        }
    }
    public void nextTextEnd()
    {
        for (int y = 0; y < texts.Length; y++)
        {
            if (screenCanvas.GetComponentInChildren<Text>().text == texts[y])
            {
                if (y < texts.Length && y != texts.Length - 1)
                {
                    screenCanvas.GetComponentInChildren<Text>().text = texts[y+1];
                    return;
                }
                else
                {
                    screenCanvas.SetActive(false);
                    //screenCanvas.GetComponentInChildren<Text>().text = "";
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //screenCanvas.GetComponentInChildren<Text>().text = "";
            if (other.tag == "Player")
            {
                if (Input.GetButtonDown("interract"))
                {
                    //screenCanvas.SetActive(true);
                }
                if (GetComponent<npcColliderVersion>().enabled == false)
                {
                    screenCanvas.GetComponentInChildren<Text>().text = texts[0];
                    player.GetComponent<playerMovement>().enabled = true;
                    screenCanvas.SetActive(true);
                }
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {/*
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("interract"))
            {
                //screenCanvas.SetActive(true);
            }
            if (GetComponent<npcColliderVersion>().enabled == false)
            {
                screenCanvas.GetComponentInChildren<Text>().text = texts[0];
                player.GetComponent<playerMovement>().enabled = true;
            }
        }*/
    }
    void OnTriggerExit2D(Collider2D other)
    {
        screenCanvas.SetActive(false);
        screenCanvas.GetComponentInChildren<Text>().text = "";
    }
}