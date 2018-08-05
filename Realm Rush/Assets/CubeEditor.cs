﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
	[Tooltip ("The size of a tile in the grid")][Range(1f, 20f)][SerializeField] float gridSize = 10.0f;

	TextMesh textMesh;

	void Update()
	{
		Vector3 snapPosition;

		gridSize = Mathf.RoundToInt(gridSize);
		snapPosition.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
		snapPosition.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
		transform.position = new Vector3(snapPosition.x, 0f, snapPosition.z);

		textMesh = GetComponentInChildren<TextMesh>();
		string XCoordinateLabel = "X: " + snapPosition.x / gridSize;
		string ZCoordinateLabel = "Z: " + snapPosition.z / gridSize;
		textMesh.text = XCoordinateLabel + "\n" + ZCoordinateLabel;
		gameObject.name = "X:" + snapPosition.x / gridSize + ", " + "Z:" + snapPosition.z / gridSize;
	}
}
