using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatformBetweenPoints : MonoBehaviour
{
    [SerializeField] Transform[] _patrolPoints;

    private void OnDrawGizmos() {
        
        DrawPoints();

        DrawPaths();
    }

    private void DrawPaths() {
        Gizmos.color = Color.blue;

        for (int i = 0; i < _patrolPoints.Length - 1; i++) {
            if (_patrolPoints[i] != null && _patrolPoints[i + 1] != null) {
                Vector3 thisPoint = _patrolPoints[i].position;
                Vector3 nextPoint = _patrolPoints[i + 1].position;
                Gizmos.DrawLine(thisPoint, nextPoint);
            } 
        }
    }

    private void DrawPoints() {
        Gizmos.color = Color.yellow;

        foreach (Transform point in _patrolPoints) {
            if (point != null)
                Gizmos.DrawSphere(point.position, .25f);
        }
    }
}
