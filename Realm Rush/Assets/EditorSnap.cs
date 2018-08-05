using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
	[Tooltip ("The size of a tile in the grid")][Range(1f, 20f)][SerializeField] float gridSize = 10.0f;

	void Update()
	{
		gridSize = Mathf.RoundToInt(gridSize);
		Vector3 snapPosition;
		snapPosition.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
		snapPosition.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
		transform.position = new Vector3(snapPosition.x, 0f, snapPosition.z);
	}
}
