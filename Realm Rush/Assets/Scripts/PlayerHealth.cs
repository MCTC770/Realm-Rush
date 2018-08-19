using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	[Range(1, 20)] public int playerHealth = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0)
		{
			Destroy(gameObject);
		}
	}
}
