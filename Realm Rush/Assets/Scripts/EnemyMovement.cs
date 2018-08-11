using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement: MonoBehaviour {

	[SerializeField][Range (0.1f, 10f)] float timeTicks = 1f;
	[SerializeField][Range(-20f, 20f)] float offset = 10f;
	List<Waypoint> path;

	// Use this for initialization
	void Start () {
		PathFinder pathfinder = FindObjectOfType<PathFinder>();
		path = pathfinder.GetPath();
		StartCoroutine(FollowPath(path));
	}

	IEnumerator FollowPath(List<Waypoint> path)
	{
		print("Starting patrol...");
		foreach (Waypoint waypoint in path)
		{
			transform.position = waypoint.transform.position;
			transform.position += new Vector3 (0, offset, 0);
			yield return new WaitForSeconds(timeTicks);
		}
		print("Ending patrol");
	}
}
