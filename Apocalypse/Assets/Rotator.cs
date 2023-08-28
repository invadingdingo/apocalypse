using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public bool canRotate = false;

    void Rotate() {
        if (canRotate && Input.GetKeyDown("W")) {
            transform.rotation = transform.rotation * Quaternion.Euler(0f, 90f, 0f);
        }
    }
}
