using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathAgent : MonoBehaviour {
    public Edge nearestEdge;

    private void Update() {
        FindNearestEdge();
    }

    private void FindNearestEdge() {
        float nearestDistance = Mathf.Infinity;
        nearestEdge = null;

        foreach (Edge edge in PathSystem.Instance.edges) {
            float distance = Vector3.Distance(transform.position, edge.transform.position);

            if (distance < nearestDistance) {
                nearestDistance = distance;
                nearestEdge = edge;
            }
        }
    }

    public Vector2 GetDirection() {
        if (nearestEdge.direction == Edge.FacingDirection.Up)
            return new Vector2(0, 1);
        else if (nearestEdge.direction == Edge.FacingDirection.Up)
            return new Vector2(0, -1);
        else if (nearestEdge.direction == Edge.FacingDirection.Left)
            return new Vector2(-1, 0);
        else
            return new Vector2(1, 0);
    }
}
