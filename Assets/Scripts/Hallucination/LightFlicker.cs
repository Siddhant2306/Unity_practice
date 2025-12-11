using UnityEngine;
using System.Collections;

public class FlickerHallucination : MonoBehaviour, IHallucination
{
    public Light[] lights;

    public void Trigger(float intensity)
    {
        foreach (Light l in lights){
            StartCoroutine(Flicker(l, intensity + Random.Range(0f, 0.2f)));
            Debug.Log($"{l.name} flicker triggered");
        }
    }

    IEnumerator Flicker(Light l, float intensity)
{
    float duration = Mathf.Lerp(0.2f, 1f, intensity);
    float baseIntensity = l.intensity;  
    for (float t = 0; t < duration; t += Time.deltaTime)
    {
    
        l.intensity = baseIntensity * Random.Range(0.7f, 1.3f);

        yield return null;
    }

  
    l.intensity = baseIntensity;
}

}
