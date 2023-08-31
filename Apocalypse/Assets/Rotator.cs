using UnityEngine;
using System.Collections;
public class Rotator : MonoBehaviour {
    float verticalInput;
    public bool rotating = false;
    public void Rotate(float direction) {
        if (!rotating)
            StartCoroutine(RotateRoutine(1, direction));
    }

    IEnumerator RotateRoutine(float duration, float direction) {
        rotating = true;
        Quaternion startRotation = transform.rotation;
        Debug.Log(startRotation);
        Quaternion endRotation = startRotation * Quaternion.Euler(0f, direction * -90f, 0f);

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