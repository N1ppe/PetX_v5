using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicSender : MonoBehaviour {

    [Range(0,10)]
    public int audioClipToPlay;

	void Start () {
		
	}
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.musicSource.clip = SoundManager.instance.inGameAudioCLips[audioClipToPlay];
            SoundManager.instance.musicSource.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.musicSource.clip = null;
        }
    }
}