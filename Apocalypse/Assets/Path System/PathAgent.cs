using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathAgent : MonoBehaviour {
    public Node currentNode;
    public bool inRange = false;
    public string axis = "x-axis";

    private void Update() {
        CheckBounds();
        if (Input.GetAxisRaw("Vertical") != 0f && inRange && !GetComponent<Rotator>().rotating) {
            ChangeAxis();
        }
    }

    public void SetCurrentNode(Node node) {
        currentNode = node; 
    }

    private void ChangeAxis() {
        if (axis == "x-axis") {
            axis = "z-axis";
            GetComponent<Rotator>().Rotate((int)currentNode.directionWhileVertical);
        } else {
            axis = "x-axis";
            GetComponent<Rotator>().Rotate((int)currentNode.directionWhileHorizontal);
        }

        transform.position = new Vector3(currentNode.transform.position.x, transform.position.y, currentNode.transform.position.z);
    }

    public void UpdateBounds() {

    }

    private void CheckBounds()  {

    }

}
