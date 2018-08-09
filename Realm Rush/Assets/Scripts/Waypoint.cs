using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

	[SerializeField] Color exploredColor;

	public bool isExplored = false;
	public Waypoint exploreFrom;

	const int gridSize = 10;
	Vector2Int gridPos;
	public bool showExploredColors;

	// Use this for initialization
	void Start ()
	{	}

	private void Update()
	{
		if (isExplored && showExploredColors)
		{
			SetTopColor(exploredColor);
		}
		else {		}
	}

	public int GetGridSize()
	{
		return gridSize;
	}
	
	public Vector2Int GetGridPos()
	{
		return new Vector2Int(
			Mathf.RoundToInt(transform.position.x / gridSize),
			Mathf.RoundToInt(transform.position.z / gridSize)
		);
	}

	public void SetTopColor(Color color)
	{
		transform.Find("Top").GetComponent<MeshRenderer>().material.color = color;
	}
}
