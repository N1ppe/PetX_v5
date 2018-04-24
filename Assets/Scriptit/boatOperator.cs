using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatOperator : MonoBehaviour {

    public GameObject UIpart,boat,player,pet;
    public GameObject start, targetloc;
    public bool movingBoatTrue = false;
    public bool movingDown = true,kickedoutBool =true;
    public float distToPlayer;
	
	void Start () {
		player = GameObject.FindWithTag("Player");
        pet = GameObject.FindWithTag("Pet");
    }
	void Update () {
        distToPlayer = Vector3.Distance(boat.transform.position, player.transform.position);
        boatOperation();
    }
    public void startBoat() {movingBoatTrue = true;kickedoutBool = false; }
    public void boatOperation()
    {
        if (movingBoatTrue == true)
        {
            UIpart.SetActive(false);

            player.GetComponent<playerMovement>().enabled = false;
            player.transform.position = boat.transform.position;
            player.transform.SetParent(boat.transform);
            player.GetComponent<SpriteRenderer>().enabled = false;
            pet.SetActive(false);

            if (movingDown == true) { boat.transform.position = Vector2.MoveTowards(boat.transform.position, targetloc.transform.position, 3 * Time.deltaTime); boat.GetComponent<SpriteRenderer>().flipY = false; }
            if(movingDown == false) { boat.transform.position = Vector2.MoveTowards(boat.transform.position, start.transform.position, 3 * Time.deltaTime); boat.GetComponent<SpriteRenderer>().flipY = true; }

            if (boat.transform.position == targetloc.transform.position) { movingBoatTrue = false; }
            if (boat.transform.position == start.transform.position) { movingBoatTrue = false; }
        }
        if (movingBoatTrue == false && kickedoutBool ==false && distToPlayer < 5)
        {
            if (boat.transform.position == targetloc.transform.position) { spitPlayerOut(); }
            if (boat.transform.position == start.transform.position) { spitPlayerOut(); }
        }
    }
    public void spitPlayerOut()
    {
        player.transform.SetParent(null);
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<playerMovement>().enabled = true;
        pet.SetActive(true);

        if (boat.transform.position == targetloc.transform.position) { player.transform.position = targetloc.transform.position + new Vector3(-4, -4, 0); }
        else if (boat.transform.position == start.transform.position) { player.transform.position = start.transform.position + new Vector3(-3, 1, 0); }
        movingDown = !movingDown;
        movingBoatTrue = false;
        kickedoutBool = true;
    }
    public void disableBoatUI()
    {
        UIpart.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            UIpart.SetActive(true);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            UIpart.SetActive(false);
        }
    }
}
