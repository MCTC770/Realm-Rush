using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage: MonoBehaviour {

	[SerializeField] int enemyHP = 3;
	[SerializeField] ParticleSystem hitParticlesPrefab;
	[SerializeField] ParticleSystem deathParticlePrefab;

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

		EnemyDeath();
	}

	private void EnemyDeath()
	{
		if (enemyHP <= 0)
		{
			Vector3 particleExplosionPosition = new Vector3(transform.position.x, transform.position.y + 9.309999f, transform.position.z);
			GameObject deathParticleCollector = GameObject.Find("Death Particles");

			ParticleSystem deathParticle = Instantiate(deathParticlePrefab, particleExplosionPosition, Quaternion.identity);
			deathParticle.transform.parent = deathParticleCollector.transform;

			Destroy(gameObject);
		}
	}
}
