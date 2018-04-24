using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingCode : MonoBehaviour {

    bool playerStateSetter=false;
    public directionToSlideTo DirectionToSlide;
    GameObject player;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	void Update ()
    {
		if(playerStateSetter == true)
        {
            switch (DirectionToSlide)
            {
                case directionToSlideTo.up:
                    player.transform.Translate(Vector3.up * 4*Time.deltaTime);
                    break;
                case directionToSlideTo.down:
                    player.transform.Translate(Vector3.down * 4*Time.deltaTime);
                    break;
                case directionToSlideTo.left:
                    player.transform.Translate(Vector3.left * 4*Time.deltaTime);
                    break;
                case directionToSlideTo.right:
                    player.transform.Translate(Vector3.right * 4*Time.deltaTime);
                    break;
            }
        }
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerStateSetter = true;
            player.GetComponent<playerMovement>().enabled = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerStateSetter = false;
            player.GetComponent<playerMovement>().enabled = true;
        }
    }
}
[System.Serializable]
public enum directionToSlideTo
{
    up,down,left,right
}