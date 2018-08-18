using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

	[SerializeField][Range (1, 10)] int towerLimit = 5;
	[SerializeField] Tower towerPrefab;

	int towerCount = 0;
	Queue<Tower> towerQueue = new Queue<Tower>();
	GameObject towerParentObject;
	Vector3 towerVector;

	public void AddTower(Waypoint baseWaypoint)
	{
		towerParentObject = GameObject.Find("Towers");
		towerVector = new Vector3(baseWaypoint.transform.position.x, baseWaypoint.transform.position.y + 10f, baseWaypoint.transform.position.z);
		towerCount += 1;

		if (towerCount <= towerLimit)
		{
			InstantiateTower(baseWaypoint);
		}
		else
		{
			RequeueTower(baseWaypoint);
		}
	}

	private void InstantiateTower(Waypoint baseWaypoint)
	{
		Tower newTower = Instantiate(towerPrefab, towerVector, Quaternion.identity);
		newTower.transform.parent = towerParentObject.transform;

		newTower.baseWaypoint = baseWaypoint;
		baseWaypoint.isPlacable = false;
		baseWaypoint.isPlaced = true;

		towerQueue.Enqueue(newTower);
	}

	private void RequeueTower(Waypoint newWaypoint)
	{
		Tower oldTower = towerQueue.Dequeue();

		oldTower.baseWaypoint.isPlacable = true;
		newWaypoint.isPlacable = false;
		oldTower.baseWaypoint.isPlaced = false;
		newWaypoint.isPlaced = true;

		oldTower.baseWaypoint = newWaypoint;

		oldTower.transform.position = newWaypoint.transform.position;

		towerQueue.Enqueue(oldTower);

		print("Tower limit reached");
		towerCount -= 1;
	}
}
