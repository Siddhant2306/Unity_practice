using UnityEngine;

public class ShadowFigureHallucination : MonoBehaviour, IHallucination
{
    public GameObject shadowPrefab;
    public Camera playerCam;
    public AudioClip audioClip;
    public AudioSource audioSource;

    public void Trigger(float intensity)
    {
        Vector3 pos = playerCam.transform.position +
                      playerCam.transform.forward * Mathf.Lerp(2f, 5f, intensity);

        GameObject obj = Instantiate(shadowPrefab, pos, Quaternion.identity);

        audioSource.PlayOneShot(audioClip);
        Debug.Log("Shadow Hallucination");
        Destroy(obj, Random.Range(0.2f, 1f));

    }
}
