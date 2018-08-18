using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement: MonoBehaviour {

	[SerializeField][Range (0.1f, 10f)] float timeTicks = 1f;
	[SerializeField][Range(-20f, 20f)] float offset = 10f;
	List<Waypoint> path;
	float moveStep = 0f;
	Vector3 startPosition;
	Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		PathFinder pathfinder = FindObjectOfType<PathFinder>();
		path = pathfinder.GetPath();
		StartCoroutine(FollowPath(path));
	}

	private void Update()
	{
		if (startPosition == new Vector3(0,0,0))
		{
			startPosition = new Vector3(0, -10, 10);
		}
		print(startPosition + " and " + targetPosition);
		transform.position = Vector3.Lerp(startPosition, targetPosition, moveStep);
		moveStep += Time.deltaTime;
		if (moveStep >= timeTicks)
		{
			startPosition = transform.position;
			moveStep = 0f;
		}
	}

	IEnumerator FollowPath(List<Waypoint> path)
	{
		print("Starting patrol...");
		foreach (Waypoint waypoint in path)
		{
			startPosition = transform.position;
			targetPosition = waypoint.transform.position + new Vector3(0, offset, 0);
			//transform.position = waypoint.transform.position;
			//transform.position += new Vector3 (0, offset, 0);
			yield return new WaitForSeconds(timeTicks);
		}
		print("Ending patrol");
	}
}
