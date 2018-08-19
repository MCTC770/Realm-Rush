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
	public int playerHealth = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		print(scoreNumber + " " + playerHealth);
		scoreUI.text = scoreNumber.ToString();
		healthUI.text = playerHealth.ToString();

	}
}
