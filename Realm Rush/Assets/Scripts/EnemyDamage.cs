using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage: MonoBehaviour {

	[SerializeField] int enemyHP = 3;
	[SerializeField] ParticleSystem hitParticlesPrefab;
	[SerializeField] ParticleSystem deathParticlePrefab;
	[SerializeField] ParticleSystem hitBaseDeathPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void OnParticleCollision(GameObject other)
	{
		hitParticlesPrefab.Play();
		enemyHP -= 1;

		EnemyDeath(false);
	}

	public void EnemyDeath(bool reachGoal)
	{
		if (enemyHP <= 0 || reachGoal)
		{
			Vector3 particleExplosionPosition = new Vector3(transform.position.x, transform.position.y + 9.309999f, transform.position.z);
			GameObject deathParticleCollector = GameObject.Find("Death Particles");
			ParticleSystem deathParticle;

			if (reachGoal == false)
			{
				deathParticle = Instantiate(deathParticlePrefab, particleExplosionPosition, Quaternion.identity);
			}
			else
			{
				deathParticle = Instantiate(hitBaseDeathPrefab, particleExplosionPosition, Quaternion.identity);
			}

			deathParticle.transform.parent = deathParticleCollector.transform;

			Destroy(deathParticle.gameObject, deathParticle.main.duration);
			Destroy(gameObject);
		}
	}
}
