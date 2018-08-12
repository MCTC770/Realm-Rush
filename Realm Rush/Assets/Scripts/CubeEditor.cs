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
		transform.position = new Vector3(
			waypoint.GetGridPos().x * gridSize,
			transform.position.y,
			waypoint.GetGridPos().y * gridSize
			);
	}

	void UpdateLabel()
	{
		TextMesh textMesh = GetComponentInChildren<TextMesh>();
		string XCoordinateLabel = "X: " + waypoint.GetGridPos().x;
		string ZCoordinateLabel = "Z: " + waypoint.GetGridPos().y;
		//textMesh.text = XCoordinateLabel + "\n" + ZCoordinateLabel; //disabled to stop errors when coordinate text is disabled
		gameObject.name = "X:" + waypoint.GetGridPos().x + ", " + "Z:" + waypoint.GetGridPos().y;
	}
}
