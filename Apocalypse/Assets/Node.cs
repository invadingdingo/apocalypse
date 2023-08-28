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
            Vector3 direction = node.transform.position - transform.position;
            float distance = direction.magnitude;

            GameObject colliderObject = new GameObject("ConnectionCollider");
            colliderObject.transform.position = transform.position + direction * 0.5f;
            colliderObject.transform.LookAt(node.transform);

            BoxCollider collider = colliderObject.AddComponent<BoxCollider>();
            collider.size = new Vector3(0.1f, 0f, distance);
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
            other.GetComponent<Rotator>().canRotate = true;
        }
    }

    void OnTriggerExit(Collider other) {
        Debug.Log(other.name);

        if (other.tag == "Player") {
            other.GetComponent<Rotator>().canRotate = false;
        }
    }
    
}
