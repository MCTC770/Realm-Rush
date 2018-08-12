using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAimer : MonoBehaviour {

	[SerializeField] Transform objectToPan;
	[SerializeField] Transform targetEnemy;
	[SerializeField][Range (0f, 10f)] float shotFrequency = 3f;
	[SerializeField] [Range(0f, 10000f)] float rateOverTime = 1f;
	[SerializeField] ParticleSystem towerLaser;

	float timer;

	void Update () {
		objectToPan.LookAt(targetEnemy);
		ShotTiming();
	}

	void ShotTiming()
	{
		var emissionTowerLaser = towerLaser.emission;

		timer += Time.deltaTime;
		if (timer > shotFrequency)
		{
			emissionTowerLaser.rateOverTime = rateOverTime;
			print(emissionTowerLaser.rateOverTime);
			timer = 0f;
		}
		else
		{
			emissionTowerLaser.rateOverTime = 0f;
		}
	}
}
