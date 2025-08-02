using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float defaultDuration = 0.5f;
    public float defaultMagnitude = 0.3f;

    public void StartShake()
    {
        StartCoroutine(Shake());
    }

    public void StartShake(float duration, float magnitude)
    {
        StartCoroutine(Shake(duration, magnitude));
    }

    IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 cameraOriginalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(cameraOriginalPos.x + x, cameraOriginalPos.y + y, cameraOriginalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = cameraOriginalPos;
    }

    IEnumerator Shake()
    {
        Vector3 cameraOriginalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < defaultDuration)
        {
            float x = Random.Range(-1f, 1f) * defaultMagnitude;
            float y = Random.Range(-1f, 1f) * defaultMagnitude;

            transform.localPosition = new Vector3(cameraOriginalPos.x + x, cameraOriginalPos.y + y, cameraOriginalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = cameraOriginalPos;
    }
}
