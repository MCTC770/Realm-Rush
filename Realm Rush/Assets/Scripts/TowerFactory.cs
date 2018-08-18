using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

	[SerializeField][Range (1, 10)] int towerLimit = 5;
	[SerializeField] GameObject towerPrefab;

	public void AddTower(Waypoint baseWaypoint)
	{
		GameObject towerParentObject = GameObject.Find("Towers");
		Vector3 towerVector = new Vector3(baseWaypoint.transform.position.x, baseWaypoint.transform.position.y + 10f, baseWaypoint.transform.position.z);

		GameObject tower = Instantiate(towerPrefab, towerVector, Quaternion.identity);
		tower.transform.parent = towerParentObject.transform;
		baseWaypoint.isPlaced = true;
		print("placeable at: " + gameObject.name);
	}
}
