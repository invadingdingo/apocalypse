using UnityEngine;
using System.Collections;
public class Rotator : MonoBehaviour {
    float verticalInput;
    public bool rotating = false;

    private void Update() {
        GetInput();
        if (!rotating) {
            // Handle rotation based on vertical input
            if (verticalInput != 0f) {
                Rotate();
            }
        }
    }

    private void Rotate() {
        //float rotationAmount = verticalInput * rotationSpeed * Time.deltaTime;
        //transform.Rotate(Vector3.up, verticalInput * 90);

        StartCoroutine(RotateRoutine(1, verticalInput));
    }

    IEnumerator RotateRoutine(float duration, float modifier) {
        Debug.Log("Here");
        rotating = true;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0f, modifier * -90f, 0f);

        float startTime = Time.time;
        float endTime = startTime + duration;

        while (Time.time < endTime) {
            float t = (Time.time - startTime) / duration;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            yield return null; // Wait for the next frame
        }

        rotating = false;
        transform.rotation = endRotation;

    }

    private void GetInput() {
        verticalInput = Input.GetAxisRaw("Vertical");
    }
}