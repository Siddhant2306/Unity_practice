using UnityEngine;
using System.Collections;

public class FlickerHallucination : MonoBehaviour, IHallucination
{
    public Light[] lights;

    public void Trigger(float intensity)
    {
        foreach (Light l in lights)
            StartCoroutine(Flicker(l, intensity));
    }

    IEnumerator Flicker(Light l, float intensity)
    {
        float duration = Mathf.Lerp(0.2f, 1f, intensity);

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            l.intensity = Random.Range(0f, 1.5f);
            yield return null;
        }

        l.intensity = 1f;
    }
}
