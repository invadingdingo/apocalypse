using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public Node[] nodes;
    
    void Awake() {
        CreateConnections();
    }
    void CreateConnections() {
        foreach (Node node in nodes)
        {
            Vector2 direction = (Vector2)(node.transform.position - transform.position);
            float distance = direction.magnitude;

            GameObject colliderObject = new GameObject("ConnectionCollider");
            colliderObject.transform.position = (Vector2)transform.position + direction * 0.5f;

            EdgeCollider2D collider = colliderObject.AddComponent<EdgeCollider2D>();
            collider.points = new Vector2[] { transform.position, node.transform.position };
        }
    }

    void Update() {
        foreach (Node node in nodes) {
            Debug.DrawLine(transform.position, node.transform.position, Color.green);
        }
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log(other.name);

        if (other.tag == "Player") {
            //other.GetComponent<Rotator>().canRotate = true;
        }
    }

    void OnTriggerExit(Collider other) {
        Debug.Log(other.name);

        if (other.tag == "Player") {
            //other.GetComponent<Rotator>().canRotate = false;
        }
    }
    
}
