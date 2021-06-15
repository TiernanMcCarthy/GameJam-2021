using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingScript : MonoBehaviour
{
	[SerializeField]
	public bool yeetItem;

	public List<GameObject> itemPrefabList;


	[SerializeField]
	private float minHeight, maxHeight;

	public GameObject target;

	[SerializeField]
	private float rotationSpeed;

	public void FixedUpdate()
	{
		if (yeetItem && Application.isPlaying)
		{
			var itemToYeetID = Random.Range(0, itemPrefabList.Count);

			var itemToYeet = Instantiate(itemPrefabList[itemToYeetID], transform.position, Quaternion.Euler(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f)));


			var projectileScript = itemToYeet.AddComponent<Projectile>();

			projectileScript.startingPos = transform.position;

			projectileScript.height = Random.Range(minHeight, maxHeight);
			projectileScript.target = target;
			projectileScript.rotationMultiplier = rotationSpeed;
			projectileScript.thrower = gameObject;

			yeetItem = false;
		}
	}
}
