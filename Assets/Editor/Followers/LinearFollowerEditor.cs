using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LinearFollower))]
public class LinearFollowerEditor : Editor
{

    private LinearFollower follower;
    
    private void OnSceneGUI()
    {
        Draw();
    }

    private void Draw()
    {
        Handles.color = Color.red;
        Vector3 newPos = Handles.FreeMoveHandle(follower.dstPoint, Quaternion.identity, 1.0f, Vector3.zero, Handles.SphereHandleCap);
        if(newPos != follower.dstPoint)
        {
            Undo.RecordObject(follower, "Move point");
            follower.dstPoint = newPos;
        }
    }

    private void OnEnable()
    {
        follower = (LinearFollower)target;
    }

}
