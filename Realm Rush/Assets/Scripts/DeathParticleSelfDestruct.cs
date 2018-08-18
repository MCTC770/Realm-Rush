using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticleSelfDestruct : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float particleDuration = GetComponent<ParticleSystem>().main.duration;
		Invoke("SelfDestruction", particleDuration);
	}
	
	void SelfDestruction()
	{
		Destroy(gameObject);
	}
}
