using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour {
    public Node startingNode;
    public Node endingNode;

    public FacingDirection direction;

    public void Initialize(Node startNode, Node endNode)
    {
        startingNode = startNode;
        endingNode = endNode;
    }

    public enum FacingDirection {
        Up, Down, Left, Right
    }
    public void Start() {
        
        if (startingNode.transform.position.x == endingNode.transform.position.x) {
            if (startingNode.transform.position.z < endingNode.transform.position.z) {
                direction = FacingDirection.Up;
            } else {
                direction = FacingDirection.Down;
            }
        } else {
            if (startingNode.transform.position.x < endingNode.transform.position.x) {
                direction = FacingDirection.Right;
            } else {
                direction = FacingDirection.Left;
            }
        }

        // Set the start and end positions
        GetComponent<LineRenderer>().SetPosition(0, startingNode.transform.position);
        GetComponent<LineRenderer>().SetPosition(1, endingNode.transform.position);
    }

}
