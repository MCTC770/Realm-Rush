using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[SerializeField] [Range(0f, 10f)] float secondsBetweenSpawns = 3f;
	[SerializeField] readonly GameObject enemyToSpawn;

	// Use this for initialization
	void Start () {
		StartCoroutine(RepeatedlySpawnEnemies());
	}

	IEnumerator RepeatedlySpawnEnemies()
	{
		while (true)
		{
			GameObject enemySpawned = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
			enemySpawned.transform.parent = this.transform;
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
	}
}
