using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

	[SerializeField][Range (1, 10)] int towerLimit = 5;
	[SerializeField] Tower towerPrefab;

	int towerCount = 0;
	Queue<Tower> towerQueue = new Queue<Tower>();

	public void AddTower(Waypoint baseWaypoint)
	{
		GameObject towerParentObject = GameObject.Find("Towers");
		Vector3 towerVector = new Vector3(baseWaypoint.transform.position.x, baseWaypoint.transform.position.y + 10f, baseWaypoint.transform.position.z);
		towerCount += 1;

		if (towerCount <= towerLimit)
		{
			Tower newTower = Instantiate(towerPrefab, towerVector, Quaternion.identity);
			newTower.transform.parent = towerParentObject.transform;
			//towerQueue.Enqueue(newTower);
			baseWaypoint.isPlaced = true;
		}
		else
		{
			//Tower oldTower = towerQueue.Dequeue();
			print("Tower limit reached " + towerQueue.Count);
			towerCount -= 1;
		}
	}
}
