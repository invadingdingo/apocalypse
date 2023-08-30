using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public Node[] nodes;
    public GameObject edgePrefab;
    
    void Awake() {
        CreateConnections();
    }
    void CreateConnections() {
        foreach (Node node in nodes) {
            GameObject edgeObj = Instantiate(edgePrefab, transform.position, Quaternion.identity);
            Edge edge = edgeObj.GetComponent<Edge>();
            PathSystem.Instance.edges.Add(edge);
            edge.Initialize(this, node); 
            edge.transform.SetParent(transform);

        }
    }
}
