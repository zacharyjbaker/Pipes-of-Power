using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    IEnumerator CamShake()
    {
        Vector3 originalPos = new Vector3(0, 0, -10);
        float time = 0f;

        while (time < 0.4f)
        {
            float yOff = Random.Range(-0.3f, 0.3f);
            float xOff = Random.Range(-0.3f, 0.3f);

            transform.localPosition = new Vector3(xOff, yOff, originalPos.z);

            time += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = originalPos;
    }

    public void Shake()
    {
        StartCoroutine(CamShake());
    }
}
