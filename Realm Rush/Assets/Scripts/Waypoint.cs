using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

	[SerializeField] Color exploredColor;

	public bool isExplored = false;
	public Waypoint exploredFrom;
	public bool isPlacable = true;

	[SerializeField] GameObject towerPrefab;

	const int gridSize = 10;
	Vector2Int gridPos;
	bool isPlaced = false;

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
				GameObject towerParentObject = GameObject.Find("Towers");
				Vector3 towerVector = new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z);

				InstantiateTower(towerParentObject, towerVector);
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
				}
			}
		}
	}

	private void InstantiateTower(GameObject towerParentObject, Vector3 towerVector)
	{
		GameObject tower = Instantiate(towerPrefab, towerVector, Quaternion.identity);
		tower.transform.parent = towerParentObject.transform;
		isPlaced = true;
		print("placeable at: " + gameObject.name);
	}
}
