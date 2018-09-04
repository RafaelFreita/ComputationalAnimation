using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Circular
{

    /// <summary>
    /// Evaluates position in circle.
    /// </summary>
    /// <returns></returns>
	public static Vector3 Evaluate(float radius, float t)
    {
        float angleInRad = Mathf.Deg2Rad * t * 360.0f;
        return new Vector3(
            Mathf.Cos(angleInRad) * radius,
            Mathf.Sin(angleInRad) * radius,
            0.0f);
    }
}
