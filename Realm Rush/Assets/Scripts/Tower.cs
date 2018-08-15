using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	[SerializeField] Transform objectToPan;
	[SerializeField] [Range (0f, 10f)] float shotFrequency = 3f;
	[SerializeField] [Range(0f, 10000f)] float rateOverTime = 1f;
	[SerializeField] [Range(0f, 100f)] float attackRange = 30f;
	[SerializeField] ParticleSystem towerLaser;

	float timer;
	bool enemyIsAlive;
	Vector3 towerPosition;
	Vector3 enemyPosition;
	float DistanceToEnemy;
	Transform targetEnemy;

	private void Start(){
		towerPosition = objectToPan.transform.position;
	}

	void Update ()
	{
		SetTargetEnemy();
		enemyIsAlive = GameObject.Find("Enemy");

		if (enemyIsAlive)
		{
			enemyPosition = targetEnemy.transform.position;
			DistanceToEnemy = Vector3.Distance(enemyPosition, towerPosition);
		}

		objectToPan.LookAt(targetEnemy);
		ShotTiming();
	}

	private void SetTargetEnemy()
	{
		EnemyDamage[] sceneEnemies = FindObjectsOfType<EnemyDamage>();
		if(sceneEnemies.Length == 0) { return; }

		Transform closestEnemy = sceneEnemies[0].transform;

		foreach (EnemyDamage testEnemy in sceneEnemies)
		{
			closestEnemy = GetClosestEnemy(closestEnemy, testEnemy.transform);
		}

		targetEnemy = closestEnemy;
	}

	private Transform GetClosestEnemy(Transform closestEnemy, Transform testEnemy)
	{
		float distanceTest = Vector3.Distance(testEnemy.position, transform.position);
		float distanceClosest = Vector3.Distance(closestEnemy.position, transform.position);

		if (distanceTest < distanceClosest)
		{
			closestEnemy = testEnemy;
		}

		return closestEnemy;
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
