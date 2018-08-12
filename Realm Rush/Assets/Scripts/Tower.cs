using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	[SerializeField] Transform objectToPan;
	[SerializeField] Transform targetEnemy;
	[SerializeField] [Range (0f, 10f)] float shotFrequency = 3f;
	[SerializeField] [Range(0f, 10000f)] float rateOverTime = 1f;
	[SerializeField] [Range(0f, 100f)] float attackRange = 30f;
	[SerializeField] ParticleSystem towerLaser;

	float timer;
	bool enemyIsAlive;
	Vector3 towerPosition;
	Vector3 enemyPosition;
	float DistanceToEnemy;

	private void Start(){
		towerPosition = objectToPan.transform.position;
	}

	void Update ()
	{
		enemyIsAlive = GameObject.Find("Enemy");

		if (enemyIsAlive)
		{
			enemyPosition = targetEnemy.transform.position;
			DistanceToEnemy = Vector3.Distance(enemyPosition, towerPosition);
		}

		objectToPan.LookAt(targetEnemy);
		ShotTiming();
	}

	void ShotTiming()
	{
		var emissionTowerLaser = towerLaser.emission;

		timer += Time.deltaTime;
		if (timer > shotFrequency && 
			enemyIsAlive && 
			DistanceToEnemy <= attackRange)
		{
			emissionTowerLaser.rateOverTime = rateOverTime;
			timer = 0f;
		}
		else
		{
			emissionTowerLaser.rateOverTime = 0f;
		}
	}
}
