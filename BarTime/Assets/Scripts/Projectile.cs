using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public Vector3 startingPos;

	public float height;

	public GameObject target;

	public float time;

	private float x, y, z;

	public float rotationMultiplier;

	public GameObject thrower;

	[SerializeField]
	public float speedMultiplier = 2f;

	[SerializeField]
	private bool shouldParabola = true;
	private void Start()
	{
		x = Random.Range(0, 45);
		y = Random.Range(0, 45);
		z = Random.Range(0, 45);

	}

	public void Update()
	{
		if (shouldParabola)
		{
			time += Time.deltaTime;
			time %= 5f;
			transform.position = ParabolaMath.Parabola(startingPos, target.transform.position, height, time / speedMultiplier);

			transform.Rotate(new Vector3(x, y, z) * rotationMultiplier * Time.deltaTime);
		}
	}


	public void OnCollisionEnter(Collision collision)
	{
		if (!collision.gameObject.Equals(thrower))
		{
			shouldParabola = false;
		}

		if (collision.gameObject.CompareTag("ThrowObstruction"))
		{
			StartCoroutine(FuckingDie());
		}
	}


	IEnumerator FuckingDie()
	{
			yield return new WaitForSeconds(2);

			Destroy(gameObject);
	}


}
