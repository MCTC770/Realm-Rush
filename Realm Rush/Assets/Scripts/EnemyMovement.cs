using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement: MonoBehaviour {

	[SerializeField] List<Waypoint> waypoints;
	[SerializeField][Range (0.1f, 10f)] float timeTicks = 1f;

	// Use this for initialization
	void Start () {
		//StartCoroutine(FollowPath());
	}

	IEnumerator FollowPath()
	{
		print("Starting patrol...");
		foreach (Waypoint waypoint in waypoints)
		{
			transform.position = waypoint.transform.position;
			yield return new WaitForSeconds(timeTicks);
			print("Visiting block: " + waypoint.name);
		}
		print("Ending patrol");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
