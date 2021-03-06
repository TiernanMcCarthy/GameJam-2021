using System;
using UnityEngine;

public class ParabolaMath
{
	public static Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
	{
		float f(float x) => -4 * height * x * x + 4 * height * x;

		var mid = Vector3.Lerp(start, end, t);

		return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
	}
}
