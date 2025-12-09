using UnityEngine;

public class WhisperHallucination : MonoBehaviour, IHallucination
{
    public AudioClip[] whispers;           
    public AudioSource audioSource;        

    [Header("Whisper Settings")]
    public float minDistance = 0.8f;       // whispers should feel closer than footsteps
    public float maxDistance = 2.5f;
    public float verticalOffset = 0.4f;    // slight variation in height

    public void Trigger(float intensity)
    {
        if (whispers.Length == 0 || audioSource == null)
            return;

        // Select random whisper clip
        AudioClip clip = whispers[Random.Range(0, whispers.Length)];

        // Random 3D position around player
        float distance = Random.Range(minDistance, maxDistance);
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;

        Vector3 randomDirection = new Vector3(
            Mathf.Cos(angle),
            Random.Range(-verticalOffset, verticalOffset), 
            Mathf.Sin(angle)
        );

        audioSource.transform.localPosition = randomDirection * distance;


        audioSource.volume = Mathf.Lerp(0.2f, 0.05f, intensity);

    
        audioSource.clip = clip;
        audioSource.spatialBlend = 1f;
        audioSource.Play();
    }
}
