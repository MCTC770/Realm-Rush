using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextDisplay : MonoBehaviour {

	[SerializeField] Text scoreUI;
	[SerializeField] Text healthUI;

	public int enemySpawnScore = 1;
	public int enemyDeathScore = 10;
	public int enemyDestinationReachedPanelty = 10;
	public int scoreNumber = 0;
	PlayerHealth playerHealthClass;

	// Use this for initialization
	void Start () {
		playerHealthClass = FindObjectOfType<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		scoreUI.text = scoreNumber.ToString();
		healthUI.text = playerHealthClass.playerHealth.ToString();

	}
}
