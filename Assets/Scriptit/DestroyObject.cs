using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

    public GameObject QuestScript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (QuestScript.GetComponent<quest>().startedQuest == true)
        {
            StartCoroutine(destroyDelay());
        }
    }
    IEnumerator destroyDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}

