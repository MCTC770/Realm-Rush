using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[SerializeField] [Range(0f, 10f)] float secondsBetweenSpawns = 3f;
	[SerializeField] GameObject enemyToSpawn;
	[SerializeField] AudioSource enemySounds;
	[SerializeField] AudioClip enemySpawnSound;

	UITextDisplay uiText;

	// Use this for initialization
	void Start () {
		uiText = FindObjectOfType<UITextDisplay>();
		StartCoroutine(RepeatedlySpawnEnemies());
	}

	IEnumerator RepeatedlySpawnEnemies()
	{
		while (true)
		{
			GameObject enemySpawned = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
			enemySounds.PlayOneShot(enemySpawnSound);
			uiText.scoreNumber += uiText.enemySpawnScore;
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
	}
}
