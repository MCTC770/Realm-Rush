using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
	TextMesh textMesh;
	Waypoint waypoint;
	Vector3 gridPos;
	int gridSize;

	private void Awake()
	{
		waypoint = GetComponent<Waypoint>();
		gridSize = waypoint.GetGridSize();
	}

	void Update()
	{
		SnapToGrid();
		UpdateLabel();
	}

	void SnapToGrid()
	{
		gridPos = waypoint.GetBlockPosition();
		transform.position = gridPos;
	}

	void UpdateLabel()
	{
		textMesh = GetComponentInChildren<TextMesh>();
		string XCoordinateLabel = "X: " + gridPos.x / gridSize;
		string ZCoordinateLabel = "Z: " + gridPos.z / gridSize;
		textMesh.text = XCoordinateLabel + "\n" + ZCoordinateLabel;
		gameObject.name = "X:" + gridPos.x / gridSize + ", " + "Z:" + gridPos.z / gridSize;
	}
}
