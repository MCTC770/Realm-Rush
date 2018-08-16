using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

	[SerializeField] Color exploredColor;

	public bool isExplored = false;
	public Waypoint exploredFrom;
	public bool isPlacable = true;

	const int gridSize = 10;
	Vector2Int gridPos;

	// Use this for initialization
	void Start ()
	{	}

	private void Update ()
	{	}

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

	private void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			print(gameObject.name + " clicked");
		}
	}
}
