﻿using System;
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

	[SerializeField] Waypoint startWaypoint;
	[SerializeField] Waypoint endWaypoint;
	[SerializeField] Color startColor = Color.green;
	[SerializeField] Color endColor = Color.red;
	[SerializeField] Color neighborColor = Color.blue;

	Waypoint neighborWaypoint;
	Waypoint[] waypoints;

	// Use this for initialization
	void Start () {
		LoadBlocks();
		ColorStartAndEnd();
		ExploreNeighbors();
	}

	private void LoadBlocks()
	{
		waypoints = FindObjectsOfType<Waypoint>();
		foreach (Waypoint waypoint in waypoints)
		{
			var gridPos = waypoint.GetGridPos();
			if (grid.ContainsKey(gridPos))
			{
				Debug.LogWarning("Skipping overlapping block: " + waypoint);
			}
			else
			{
				grid.Add(gridPos, waypoint);
			}
		}
		print("Loaded " + grid.Count + " blocks");
	}

	private void ColorStartAndEnd()
	{
		startWaypoint.SetTopColor(startColor);
		endWaypoint.SetTopColor(endColor);
	}

	void ExploreNeighbors()
	{
		neighborWaypoint = FindObjectOfType<Waypoint>();
		neighborWaypoint = startWaypoint;
		foreach (Vector2Int direction in directions)
		{
			Vector2Int neighborPositionVector = neighborWaypoint.GetGridPos() + direction;
			try
			{
				grid[neighborPositionVector].SetTopColor(neighborColor);
				print("Exploring " + neighborPositionVector);
			}
			catch
			{
				Debug.Log("Neighbor doesn't exist on coordinate " + neighborPositionVector);
			}
		}
	}
}
