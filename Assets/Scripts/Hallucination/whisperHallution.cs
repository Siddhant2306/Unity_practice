using UnityEngine;

public class WhisperHallucination : MonoBehaviour, IHallucination
{
    public AudioSource audioSource;
    public AudioClip[] whispers;

    public void Trigger(float intensity)
    {
        if (whispers.Length == 0) return;

        AudioClip clip = whispers[Random.Range(0, whispers.Length)];

        audioSource.PlayOneShot(clip, Mathf.Lerp(0.1f, 0.5f, intensity));
    }
}
