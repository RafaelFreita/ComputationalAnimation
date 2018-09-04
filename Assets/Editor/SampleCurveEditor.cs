using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SampleCurve))]
public class SampleCurveEditor : Editor
{

    private SampleCurve _curve;
    private Material _mat;
    private const uint iterations = 50;

    private void OnEnable()
    {
        _curve = (SampleCurve)target;
        Shader shader = Shader.Find("Hidden/Internal-Colored");
        _mat = new Material(shader);
    }
    private void OnDisable()
    {
        DestroyImmediate(_mat);
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Rect rect = GUILayoutUtility.GetRect(10, 1000, 200, 200);
        if (Event.current.type == EventType.Repaint)
        {
            GUI.BeginClip(rect);
            GL.PushMatrix();
            
            GL.Clear(true, false, Color.black);
            _mat.SetPass(0);

            // Background
            GL.Begin(GL.QUADS);
            GL.Color(Color.gray);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(rect.width, 0, 0);
            GL.Vertex3(rect.width, rect.height, 0);
            GL.Vertex3(0, rect.height, 0);
            GL.End();

            // Draw data
            List<Vector3> nodes = _curve.nodes;

            Vector3 p0 = nodes[0];
            Vector3 p1 = nodes[1];
            Vector3 p2 = nodes[2];
            Vector3 p3 = nodes[3];

            GL.Color(Color.red);
            for (int i = 0; i < 4; i++)
            {
                GL.Begin(GL.QUADS);
                GL.Vertex3(nodes[i].x * rect.width - 5.0f, rect.height - nodes[i].y * rect.height - 5.0f, 0);
                GL.Vertex3(nodes[i].x * rect.width + 5.0f, rect.height - nodes[i].y * rect.height - 5.0f, 0);
                GL.Vertex3(nodes[i].x * rect.width + 5.0f, rect.height - nodes[i].y * rect.height + 5.0f, 0);
                GL.Vertex3(nodes[i].x * rect.width - 5.0f, rect.height - nodes[i].y * rect.height + 5.0f, 0);
                GL.End();
            }

            GL.Begin(GL.LINE_STRIP);
            GL.Color(Color.green);
            float t = 1.0f / iterations;
            for (float i = 0; i <= 1.0f; i += t)
            {
                Vector3 val = Bezier.EvaluateCubicCurve(p0, p1, p2, p3, i);
                GL.Vertex3(val.x * rect.width, rect.height - val.y * rect.height, 0);
            }
            GL.End();

            GL.PopMatrix();

            GUI.EndClip();
        }
    }
}
