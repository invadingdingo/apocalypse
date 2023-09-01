using UnityEngine;
using System.Collections;
public class Rotator : MonoBehaviour {
    float verticalInput;
    public float rotateTime = 0.5f;
    public bool rotating = false;
    public void Rotate(float direction) {
        if (!rotating)
            StartCoroutine(RotateRoutine(rotateTime, direction));
    }

    IEnumerator RotateRoutine(float duration, float newRotation) {
        rotating = true;
        Quaternion startRotation = transform.rotation;
        Debug.Log(startRotation);
        Quaternion endRotation = startRotation * Quaternion.Euler(0f, (newRotation * 90), 0f);

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
}