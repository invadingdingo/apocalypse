using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    
    public float verticalCameraDirection;
    public float horizontalCameraDirection;

    void OnTriggerEnter(Collider other) {
        Debug.Log("Entgered");
        if (other.GetComponent<PathAgent>()) {
            other.gameObject.GetComponent<PathAgent>().SetCurrentNode(this);
            other.gameObject.GetComponent<PathAgent>().UpdateBounds();
            other.gameObject.GetComponent<PathAgent>().inRange = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.GetComponent<PathAgent>()) {
            other.gameObject.GetComponent<PathAgent>().inRange = false;
        }
    }



}
