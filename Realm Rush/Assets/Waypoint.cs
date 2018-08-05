using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

	const int gridSize = 10;
	Vector3 gridPos;

	// Use this for initialization
	void Start () {
		gridPos = transform.position;
	}

	public int GetGridSize()
	{
		return gridSize;
	}
	
	public Vector3 GetBlockPosition()
	{
		gridPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
		gridPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

		return gridPos;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
