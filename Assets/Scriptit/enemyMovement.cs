using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

    Animator enemysAnimator;
    public GameObject player;
    public float distToPlayer;
    public state EnemyState=state.idle;
    [Range(0,3)]
    public int health;
    //public gamemanagement gm;
    public GameObject gm;

    void Start ()
    {
        enemysAnimator = GetComponentInChildren<Animator>();
        player = GameObject.FindWithTag("Player");
        gm = GameObject.FindWithTag("GameManagementTag");
    }
	void Update ()
    {
        //if (distToPlayer < 10) { animationChanger(); }
        if(EnemyState != state.dead && health>0)
        {
            distToPlayer = Vector3.Distance(this.transform.position, player.transform.position);
            if (distToPlayer < 8 && distToPlayer > 0) { EnemyState = state.following; }
            else if (distToPlayer <= 2.5f) { EnemyState = state.attack; }
            else if(distToPlayer >= 10f) { EnemyState = state.idle; }
            if (health <= 0) { EnemyState = state.dead; }

            if (EnemyState == state.following && player.GetComponent<playerAttacking>().playerHealth > 0)
            {
                this.gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, Time.deltaTime * 2.5f);
                StartCoroutine(randDelay());
            }
            if (health <= 0) { EnemyState = state.dead; }
        }
        else
        {
            if (gameObject.GetComponent<BoxCollider2D>().enabled == true)
            {
                gm.GetComponent<gamemanagement>().currentPetAttackGain();
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            StartCoroutine(deathStateOperation());
        }
    }
    /*
    public void animationChanger()
    {
        if (EnemyState == state.idle) { enemysAnimator.SetInteger("enemyStateInt", 0); }
        if (EnemyState == state.following) { enemysAnimator.SetInteger("enemyStateInt", 1); }
        if (EnemyState == state.attack) { enemysAnimator.SetInteger("enemyStateInt", 2); }
        if (EnemyState == state.dead) { enemysAnimator.SetInteger("enemyStateInt", 3); }
    }
    */
    public void kickbacking()
    {
        if (Facing.dirFacing == Facing.directionFacing.down) { this.GetComponent<Rigidbody2D>().AddForce(Vector2.down*500); }
        if (Facing.dirFacing == Facing.directionFacing.downleft) { this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1,-1) * 500); }
        if (Facing.dirFacing == Facing.directionFacing.left) { this.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 500); }
        if (Facing.dirFacing == Facing.directionFacing.upleft) { this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 1) * 500); }
        if (Facing.dirFacing == Facing.directionFacing.up) { this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500); }
        if (Facing.dirFacing == Facing.directionFacing.upright) { this.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * 500); }
        if (Facing.dirFacing == Facing.directionFacing.right) { this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 500); }
        if (Facing.dirFacing == Facing.directionFacing.downright) { this.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, -1) * 500); }
        StartCoroutine(disablekickback());
    }
    IEnumerator disablekickback()
    {
        yield return new WaitForSeconds(0.2f);
        this.GetComponent<Rigidbody2D>().Sleep();
        yield return new WaitForSeconds(0.01f);
        this.GetComponent<Rigidbody2D>().WakeUp();
    }
    IEnumerator randDelay()
    {
        if (health < 0)
        { EnemyState = state.following; }
        yield return new WaitForSeconds(Random.Range(1,4));
        if (health < 0)
        { EnemyState = state.idle; }
    }
    IEnumerator deathStateOperation()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(0.25f);
        this.gameObject.GetComponent<lootDrop>().itemAssigningAndSpawn();
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerAttack" )
        {
            health = health-1;
            kickbacking();
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<playerAttacking>().playerHealth = player.GetComponent<playerAttacking>().playerHealth-1;
        }
    }
}
public enum state
{
idle,following,attack,dead
}
