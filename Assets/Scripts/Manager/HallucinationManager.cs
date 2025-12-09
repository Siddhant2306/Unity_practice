using UnityEngine;

public class HallucinationManager : MonoBehaviour
{
    public float intensity = 0f;  
    public float minTime = 5f;
    public float maxTime = 15f;

    private float nextTime;

    private IHallucination[] hallucinations;

    void Start()
    {
        hallucinations = GetComponents<IHallucination>();
        ScheduleNext();
    }

    void Update()
    {
        if (Time.time >= nextTime)
        {
            TriggerRandom();
            ScheduleNext();
        }
    }

    void ScheduleNext()
    {
        float t = Mathf.Lerp(maxTime, minTime, intensity);
        nextTime = Time.time + Random.Range(t * 0.7f, t * 1.2f);
    }

    void TriggerRandom()
    {
        if (hallucinations.Length == 0) return;

        IHallucination h = hallucinations[Random.Range(0, hallucinations.Length)];
        h.Trigger(intensity);
    }
}
