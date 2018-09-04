using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCurve : MonoBehaviour {

    [SerializeField]
    public List<Vector3> nodes = new List<Vector3>(4);

    public float Evaluate(float x)
    {
        return Bezier.EvaluateCubicCurve(nodes[0], nodes[1], nodes[2], nodes[3], x).y;
    }

}
