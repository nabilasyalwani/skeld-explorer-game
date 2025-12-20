using UnityEngine;

public class AudioGameController : MonoBehaviour
{
    [SerializeField] private AudioSource introSource;
    [SerializeField] private AudioSource gamePlaySource;

    private void Update()
    {
        if (introSource.isPlaying) return;
        if (!gamePlaySource.isPlaying)
            gamePlaySource.Play();
    }
}
