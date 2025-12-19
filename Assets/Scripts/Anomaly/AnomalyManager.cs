using UnityEngine;
using System.Collections;

public class AnomalyManager : MonoBehaviour
{
    [Header("Anomaly Timing")]
    public float minInterval = 5f;
    public float maxInterval = 12f;

    [Header("Anomaly Strength")]
    public float anomalyIntensity = 0.3f;
    public float anomalyDuration = 3f;

    private AnomalyObjects[] anomalyObjects;

    void Start()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("AnomalyObjects");

        anomalyObjects = new AnomalyObjects[taggedObjects.Length];

        for (int i = 0; i < taggedObjects.Length; i++)
        {
          
            if (!taggedObjects[i].TryGetComponent(out AnomalyObjects anomaly))
            {
             
                anomaly = taggedObjects[i].AddComponent<AnomalyObjects>();
            }

            anomalyObjects[i] = anomaly;
        }

        StartCoroutine(AnomalyLoop());
    }

    IEnumerator AnomalyLoop()
    {
        while (true)
        {
            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);

            TriggerRandomAnomaly();
        }
    }

    void TriggerRandomAnomaly()
    {
        if (anomalyObjects.Length == 0) return;

        AnomalyObjects obj =
            anomalyObjects[Random.Range(0, anomalyObjects.Length)];

        Debug.Log($"[ANOMALY] Triggered on: {obj.gameObject.name}");

        StartCoroutine(HandleAnomaly(obj));
    }

    IEnumerator HandleAnomaly(AnomalyObjects obj)
    {
        obj.ActivateAnomaly(anomalyIntensity);

        yield return new WaitForSeconds(anomalyDuration);

        Debug.Log($"[ANOMALY] Reset: {obj.gameObject.name}");

        obj.ResetAnomaly();
    }
}
