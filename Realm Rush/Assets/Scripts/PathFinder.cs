using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	Queue<Waypoint> queue = new Queue<Waypoint>();
	bool isRunning = true;
	Waypoint searchCenter;
	List<Waypoint> path = new List<Waypoint>();

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
	[SerializeField] Color exploredColor;

	Waypoint neighborWaypoint;
	Waypoint[] waypoints;

	public List<Waypoint> GetPath()
	{
		LoadBlocks();
		ColorStartAndEnd();
		BreadthFirstSearch();
		CreatePath();
		return path;
	}

	private void CreatePath()
	{
		path.Add(endWaypoint);
		Waypoint previous = endWaypoint.exploredFrom;
		while (previous != startWaypoint)
		{
			path.Add(previous);
			previous = previous.exploredFrom;
		}

		path.Add(startWaypoint);
		path.Reverse();
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

	void BreadthFirstSearch()
	{
		queue.Enqueue(startWaypoint);

		while (queue.Count > 0 && isRunning)
		{
			searchCenter = queue.Dequeue();
			searchCenter.isExplored = true;
			print("Searching from: " + searchCenter);
			HaltIfEndFound();
			ExploreNeighbors();
		}

		print("Finished pathfinding?");
	}

	private void HaltIfEndFound()
	{
		if (searchCenter == endWaypoint)
		{
			isRunning = false;
		}
	}

	void ExploreNeighbors()
	{
		if (!isRunning) { return; }
		neighborWaypoint = FindObjectOfType<Waypoint>();
		neighborWaypoint = startWaypoint;
		foreach (Vector2Int direction in directions)
		{
			Vector2Int neighborCoordinates = searchCenter.GetGridPos() + direction;
			if (grid.ContainsKey(neighborCoordinates))
			{
				QueueNewNeighbors(neighborCoordinates);
			}
		}
	}

	private void QueueNewNeighbors(Vector2Int neighborCoordinates)
	{
		Waypoint neighbor = grid[neighborCoordinates];
		if (neighbor.isExplored || queue.Contains(neighbor)){}	
		else
		{
			queue.Enqueue(neighbor);
			neighbor.exploredFrom = searchCenter;
			print("Exploring " + neighborCoordinates);
		}
	}
}
