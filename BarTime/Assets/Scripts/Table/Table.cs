using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
	public int numberOfChairs;
	public float radius;

	public bool rejiggyTables = true;
	public bool useRandomNumber = true;
	[SerializeField]
	private int minChairs, MaxChairs;

	public Chair chairPrefab;

	public List<Punter> inhabitantList;

	public List<Chair> chairList;

	public bool Team;
	
	public void Start()
	{
		rejiggyTables = true;
		if (rejiggyTables && Application.isPlaying)
		{
			if (useRandomNumber) numberOfChairs = Random.Range(minChairs, MaxChairs);

			SpawnChairsAroundTable(numberOfChairs, transform.position, radius);
			rejiggyTables = false;
		}
	}


    public void SpawnChairsAroundTable(int chairs, Vector3 point, float radius)
	{
		foreach (var chair in chairList)
		{
			Destroy(chair);
		}

		for (int i = 0; i < chairs; i++)
		{

			/* Distance around the circle */
			var radians = 2 * Mathf.PI / chairs * i;

			/* Get the vector direction */
			var vertical = Mathf.Sin(radians);
			var horizontal = Mathf.Cos(radians);

			var spawnDir = new Vector3(horizontal, 0, vertical);

			/* Get the spawn position */
			var spawnPos = point + spawnDir * radius; // Radius is just the distance away from the point

			/* Now spawn */
			var chair = Instantiate(chairPrefab, spawnPos, Quaternion.identity);
			chair.Owner = this;
			/* Add chair to list */
			chairList.Add(chair);
			
			/* Rotate the enemy to face towards player */
			chair.transform.LookAt(point);

			/* Adjust height */
			chair.transform.position = new Vector3(chair.transform.position.x, 0.4f, chair.transform.position.z);
		}
	}
}
