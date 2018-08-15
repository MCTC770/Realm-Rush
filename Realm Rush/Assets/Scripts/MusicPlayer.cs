using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	AudioSource backgroundMusic;

	void Awake () {
		backgroundMusic = GetComponent<AudioSource>();
		if (backgroundMusic.enabled == false)
		{
			backgroundMusic.enabled = true;
		}

	}
}
