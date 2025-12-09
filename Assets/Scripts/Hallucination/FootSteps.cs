using UnityEngine;

public class FootstepHallucination : MonoBehaviour, IHallucination
{
    public AudioClip[] clips;             
    public AudioSource audioSource;        
    
    [Header("Footstep Settings")]
    public float minDistance = 1.5f;       
    public float maxDistance = 3.5f;      
    public float verticalOffset = 0.3f;  

    public void Trigger(float intensity)
    {
        if (clips.Length == 0 || audioSource == null)
            return;

      
        AudioClip clip = clips[Random.Range(0, clips.Length)];

       
        float distance = Random.Range(minDistance, maxDistance);
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;

       
        Vector3 randomDirection = new Vector3(
            Mathf.Cos(angle),
            Random.Range(-verticalOffset, verticalOffset), 
            Mathf.Sin(angle)
        );

    
        audioSource.transform.localPosition = randomDirection * distance;

      
        audioSource.volume = Mathf.Lerp(0.5f, 0.1f, intensity);

        
        audioSource.clip = clip;
        audioSource.spatialBlend = 1f; 
        audioSource.Play();
    }
}
