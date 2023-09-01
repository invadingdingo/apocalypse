using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    
    [HideInInspector]
    public Direction directionWhileVertical;

    public bool capNode = false;
    public Direction directionWhileHorizontal;

    public bool upCollider;
    public bool downCollider;
    public bool leftCollider;
    public bool rightCollider;

    public enum Direction {
        Clockwise = -1,
        CounterClockwise = 1
    }

    void Awake() {

        CreateColliders();

        if (directionWhileHorizontal == Direction.Clockwise) {
            directionWhileVertical = Direction.CounterClockwise;
        } else {
            directionWhileVertical = Direction.Clockwise;
        }
    }

    void CreateColliders() {
        if (upCollider) {
            // Calculate the position of the collider
            Vector3 colliderPosition = transform.position + new Vector3(0, 0, 1f);
            CreateCollider(colliderPosition);
        }

        if (downCollider) {
            // Calculate the position of the collider
            Vector3 colliderPosition = transform.position + new Vector3(0, 0, -1f);
            CreateCollider(colliderPosition);
        }

        if (leftCollider) {
            // Calculate the position of the collider
            Vector3 colliderPosition = transform.position + new Vector3(-1f, 0, 0);
            CreateCollider(colliderPosition);
        }

        if (rightCollider) {
            // Calculate the position of the collider
            Vector3 colliderPosition = transform.position + new Vector3(1f, 0, 0);
            CreateCollider(colliderPosition);
        }
    }

    void CreateCollider(Vector3 position) {
        GameObject colliderObject = new GameObject(gameObject.name + " Collider");
        colliderObject.transform.position = position;
        BoxCollider boxCollider = colliderObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(1f, 20f, 1f);
    }

    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<PathAgent>() && !capNode) {
            other.gameObject.GetComponent<PathAgent>().SetCurrentNode(this);
            other.gameObject.GetComponent<PathAgent>().UpdateBounds();
            other.gameObject.GetComponent<PathAgent>().inRange = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.GetComponent<PathAgent>() && !capNode) {
            other.gameObject.GetComponent<PathAgent>().inRange = false;
        }
    }



}
