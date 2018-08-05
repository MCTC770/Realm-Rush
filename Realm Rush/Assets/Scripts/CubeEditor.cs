using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
	Waypoint waypoint;
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
		Vector3 gridPos = waypoint.GetGridPos();
		transform.position = new Vector3(
			waypoint.GetGridPos().x,
			0f,
			waypoint.GetGridPos().y
			);
	}

	void UpdateLabel()
	{
		TextMesh textMesh = GetComponentInChildren<TextMesh>();
		string XCoordinateLabel = "X: " + waypoint.GetGridPos().x / gridSize;
		string ZCoordinateLabel = "Z: " + waypoint.GetGridPos().y / gridSize;
		textMesh.text = XCoordinateLabel + "\n" + ZCoordinateLabel;
		gameObject.name = "X:" + waypoint.GetGridPos().x / gridSize + ", " + "Z:" + waypoint.GetGridPos().y / gridSize;
	}
}
