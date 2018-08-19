using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	[Range(1, 20)] public int playerHealth = 10;

	UITextDisplay uiText;

	// Use this for initialization
	void Start () {
		uiText = FindObjectOfType<UITextDisplay>();
	}
	
	// Update is called once per frame
	void Update () {

		uiText.playerHealth = playerHealth;

		if (playerHealth <= 0)
		{
			Destroy(gameObject);
		}
	}
}
