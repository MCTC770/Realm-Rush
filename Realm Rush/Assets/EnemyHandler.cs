using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour {

	[SerializeField] int enemyHP = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnParticleCollision(GameObject other)
	{
		enemyHP -= 1;
		EnemyHit();
	}

	private void EnemyHit()
	{
		if (enemyHP <= 0)
		{
			Destroy(gameObject);
		}
	}
}
