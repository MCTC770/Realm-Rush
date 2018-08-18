using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	[SerializeField] Transform objectToPan;
	[SerializeField] [Range (0f, 10f)] float shotFrequency = 3f;
	[SerializeField] [Range(0f, 5f)] float rateOverTime = 1f;
	[SerializeField] [Range(0f, 100f)] float attackRange = 30f;
	[SerializeField] ParticleSystem towerLaser;

	float timer;
	float laserTime;
	bool enemyIsAlive;
	Vector3 towerPosition;
	Vector3 enemyPosition;
	float DistanceToEnemy;
	Transform targetEnemy;
	AudioSource laserBeam;
	bool isEmitting = false;
	bool coroutineStarted = false;
	bool laserTimerOverThreshold = false;

	public Waypoint baseWaypoint;

	private void Start(){
		laserBeam = GetComponentInChildren<AudioSource>();
		towerPosition = objectToPan.transform.position;
	}

	void Update ()
	{
		SetTargetEnemy();
		enemyIsAlive = GameObject.Find("Enemy(Clone)");

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
			laserTime += Time.deltaTime;

			if (laserTime >= 1 / rateOverTime)
			{
				laserTimerOverThreshold = true;
			}

			isEmitting = true;
			emissionTowerLaser.rateOverTime = rateOverTime;
			if (coroutineStarted == false && laserTimerOverThreshold == true)
			{
				StartCoroutine(LaserShotFrequency());
			}
			timer = 0f;
		}
		else
		{
			coroutineStarted = false;
			laserTimerOverThreshold = false;
			isEmitting = false;
			emissionTowerLaser.rateOverTime = 0f;
			laserBeam.enabled = false;
		}

		
	}

	IEnumerator LaserShotFrequency()
	{
		coroutineStarted = true;
		while (isEmitting)
		{
			laserBeam.enabled = true;
			yield return new WaitForSeconds(1 / rateOverTime);
			laserBeam.enabled = false;
		}
	}
}
