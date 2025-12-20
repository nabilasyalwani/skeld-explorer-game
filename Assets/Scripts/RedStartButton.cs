using Unity.Cinemachine;
using UnityEngine;
using System.Collections;

public class RedStartButton : MonoBehaviour
{
    public CinemachineCamera mainCam;
    public CinemachineCamera sideCam;

    public GameObject startText;
    public GameObject logo;
    public CanvasGroup playMenu;

    [SerializeField] private float delay = 1.0f;
    [SerializeField] private float fadeDuration = 0.5f;

    public void OnClicked()
    {
        mainCam.Priority = 10;
        sideCam.Priority = 20;

        startText.SetActive(false);
        logo.SetActive(false);

        StartCoroutine(ShowPlayMenuAfterDelay());
    }

    private IEnumerator ShowPlayMenuAfterDelay()
    {
        playMenu.gameObject.SetActive(true);
        playMenu.alpha = 0;
        playMenu.interactable = false;
        playMenu.blocksRaycasts = false;

        yield return new WaitForSeconds(delay);

        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            playMenu.alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            yield return null;
        }

        playMenu.alpha = 1f;
        playMenu.interactable = true;
        playMenu.blocksRaycasts = true;
    }


}
