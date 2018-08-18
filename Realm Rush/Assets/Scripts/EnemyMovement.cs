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
	Quaternion startRotation;
	Quaternion targetRotation;

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
		transform.rotation = Quaternion.Slerp(startRotation, targetRotation, moveStep * 2);
		moveStep += Time.deltaTime;
		if (moveStep >= timeTicks)
		{
			float x = Mathf.Round(transform.position.x);
			float y = Mathf.Round(transform.position.y);
			float z = Mathf.Round(transform.position.z);
			startPosition = new Vector3(x,y,z);
			startRotation = transform.rotation;
			moveStep = 0f;
		}
	}

	IEnumerator FollowPath(List<Waypoint> path)
	{
		print("Starting patrol...");
		foreach (Waypoint waypoint in path)
		{
			targetPosition = waypoint.transform.position + new Vector3(0, offset, 0);
			targetRotation = Quaternion.LookRotation((targetPosition - transform.position), Vector3.up);
			yield return new WaitForSeconds(timeTicks);
		}
		print("Ending patrol");
	}
}
