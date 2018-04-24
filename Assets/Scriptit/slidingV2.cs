using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingV2 : MonoBehaviour {

    bool playerStateSetter = false;
    GameObject player;
    public GameObject parentSlideController;

    public isDirGiver IsDirGiver;
    public directionToSlideToV2 DirectionToSlide;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (IsDirGiver == isDirGiver.NO && DirectionToSlide != directionToSlideToV2.NONE)
        {
            switch (DirectionToSlide)
            {
                case directionToSlideToV2.up:
                    player.transform.Translate(Vector3.up * 15 * Time.deltaTime);
                    break;
                case directionToSlideToV2.down:
                    player.transform.Translate(Vector3.down * 15 * Time.deltaTime);
                    break;
                case directionToSlideToV2.left:
                    player.transform.Translate(Vector3.left * 15 * Time.deltaTime);
                    break;
                case directionToSlideToV2.right:
                    player.transform.Translate(Vector3.right * 15 * Time.deltaTime);
                    break;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (IsDirGiver == isDirGiver.NO)
            {
            }
            if (IsDirGiver == isDirGiver.start && parentSlideController.GetComponent<slidingV2>().DirectionToSlide == directionToSlideToV2.NONE)
            {
                switch (DirectionToSlide)
                {
                    case directionToSlideToV2.up:
                        parentSlideController.GetComponent<slidingV2>().DirectionToSlide = directionToSlideToV2.up;
                        break;
                    case directionToSlideToV2.down:
                        parentSlideController.GetComponent<slidingV2>().DirectionToSlide = directionToSlideToV2.down;
                        break;
                    case directionToSlideToV2.left:
                        parentSlideController.GetComponent<slidingV2>().DirectionToSlide = directionToSlideToV2.left;
                        break;
                    case directionToSlideToV2.right:
                        parentSlideController.GetComponent<slidingV2>().DirectionToSlide = directionToSlideToV2.right;
                        break;
                }
            }
            if (IsDirGiver == isDirGiver.stop)
            {
                parentSlideController.GetComponent<slidingV2>().DirectionToSlide = directionToSlideToV2.NONE;
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //playerStateSetter = true;
            //player.GetComponent<playerMovement>().enabled = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //playerStateSetter = false;
            //player.GetComponent<playerMovement>().enabled = true;
        }
    }
}
[System.Serializable]
public enum directionToSlideToV2
{
    NONE,up, down, left, right
}
public enum isDirGiver
{
    NO,start,stop
}