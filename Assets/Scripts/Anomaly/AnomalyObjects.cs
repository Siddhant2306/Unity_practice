using UnityEngine;

public class AnomalyObjects : MonoBehaviour
{
    private Vector3 originalLocalPos;
    private Quaternion originalLocalRot;

    private bool isActive;

    void Awake()
    {
        originalLocalPos = transform.localPosition;
        originalLocalRot = transform.localRotation;
    }

    public void ActivateAnomaly(float intensity)
    {
        if (isActive) return;
        isActive = true;

        Vector3 offset = Random.insideUnitSphere * intensity;
        transform.localPosition = originalLocalPos + offset;

        float rotAmount = intensity * 10f;
        transform.localRotation =
            originalLocalRot *
            Quaternion.Euler(
                Random.Range(-rotAmount, rotAmount),
                Random.Range(-rotAmount, rotAmount),
                0f
            );
    }

    public void ResetAnomaly()
    {
        isActive = false;
        transform.localPosition = originalLocalPos;
        transform.localRotation = originalLocalRot;
    }
}
