using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

	[SerializeField] Color exploredColor;

	public bool isExplored = false;
	public Waypoint exploredFrom;
	public bool isPlacable = true;
	public bool isPlaced = false;

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
			if (isPlacable && isPlaced == false)
			{
				InstantiateTower();
			}
			else
			{
				if (isPlaced)
				{
					print("another tower already exists at: " + gameObject.name);
				}
				else
				{
					print("can't place at: " + gameObject.name);
					MoveExistingTower();
				}
			}
		}
	}

	private void MoveExistingTower()
	{
		throw new NotImplementedException();
	}

	private void InstantiateTower()
	{
		print("placeable at: " + gameObject.name);
		FindObjectOfType<TowerFactory>().AddTower(this);
	}
}
