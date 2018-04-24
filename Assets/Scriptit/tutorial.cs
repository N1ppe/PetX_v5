using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour {
    GameObject gm;
    public bool tutorialDisabled;
    public GameObject player,pet,textBox,petCanvasPart;
    public int speechBubbleInt=0;
    public string[] tutoSpeak;
	void Start ()
    {
        gm = GameObject.FindWithTag("GameManagementTag");
        player = GameObject.FindWithTag("Player");
        pet = GameObject.FindWithTag("Pet");
    }
	void Update ()
    {
        if (speechBubbleInt < tutoSpeak.Length) { textBox.GetComponent<Text>().text = tutoSpeak[speechBubbleInt]; }
        if (Input.GetButtonDown("interract") && speechBubbleInt != 2)
        {
            switch (speechBubbleInt)
            {
                case 1:
                    textBox.GetComponent<Text>().enabled = true;
                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:
                    textBox.GetComponent<Text>().text = tutoSpeak[4];
                    textBox.SetActive(false);
                    player.GetComponent<playerMovement>().enabled = true;
                    player.GetComponent<playerAttacking>().enabled = true;
                    tutorialDisabled = true;
                    break;
                default:
                    break;
            }
            speechBubbleInt = speechBubbleInt + 1;
            /*
            if (speechBubbleInt < tutoSpeak.Length)
            {
                speechBubbleInt = speechBubbleInt + 1;
                if (speechBubbleInt < tutoSpeak.Length)
                {
                    textBox.GetComponent<Text>().text = tutoSpeak[speechBubbleInt];
                }
                //---------------------------------------------------------------------------last
                else if (speechBubbleInt == tutoSpeak.Length)
                {
                    textBox.SetActive(false);
                    Destroy(textBox);
                    player.GetComponent<playerMovement>().enabled = true;
                    player.GetComponent<playerAttacking>().enabled = true;
                    tutorialDisabled = true;
                }
            }*/
        }
        if (speechBubbleInt == 2)
        {
            if(gm.GetComponent<gamemanagement>().Pet != gm.GetComponent<gamemanagement>().AllMonsters[0])
            {
                player.GetComponent<playerButtonControl>().openWindow = openCanvas.NONE;
                petCanvasPart.SetActive(false);
                Time.timeScale = 1;
                speechBubbleInt = speechBubbleInt + 1;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && tutorialDisabled == false)
        {
            player.GetComponent<Animator>().SetBool("walking", false);
            player.GetComponent<playerMovement>().enabled = false;
            player.GetComponent<playerAttacking>().enabled = false;

            textBox.transform.position = pet.transform.position;
            textBox.SetActive(true);
            textBox.GetComponent<Text>().text = tutoSpeak[0];
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
