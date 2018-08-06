using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	Vector2Int[] directions =
	{
		Vector2Int.up,
		Vector2Int.right,
		Vector2Int.down,
		Vector2Int.left
	};

	[SerializeField] GameObject startPosition;
	[SerializeField] GameObject endPosition;
	[SerializeField] Color startColor = Color.green;
	[SerializeField] Color endColor = Color.red;
	[SerializeField] Color neighborColor = Color.blue;

	GameObject neighborPosition;
	Waypoint[] waypoints;
	Waypoint singleWaypoint;

	// Use this for initialization
	void Start () {
		LoadBlocks();
		ExploreNeighbors();
	}

	void ExploreNeighbors()
	{
		singleWaypoint = FindObjectOfType<Waypoint>();
		int gridSize = singleWaypoint.GetGridSize();
		foreach (Vector2Int direction in directions)
		{
			Vector2Int neighborPositionVector = new Vector2Int 
			(
				Mathf.RoundToInt(startPosition.transform.position.x) / gridSize + direction.x, 
				Mathf.RoundToInt(startPosition.transform.position.z) / gridSize + direction.y
			);
		}
	}

	private void LoadBlocks()
	{
		waypoints = FindObjectsOfType<Waypoint>();
		foreach(Waypoint waypoint in waypoints)
		{
			var gridPos = waypoint.GetGridPos();
			if (grid.ContainsKey(gridPos))
			{
				Debug.LogWarning("Skipping overlapping block: " + waypoint);
			}
			else
			{
				grid.Add(gridPos, waypoint);
				waypoint.SetTopColor(startPosition, startColor);
				waypoint.SetTopColor(endPosition, endColor);
			}
		}
		print("Loaded " + grid.Count + " blocks");
	}
}
