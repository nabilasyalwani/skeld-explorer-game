using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraIntroController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera[] introCams;
    [SerializeField] private CinemachineCamera gameplayCam;
    [SerializeField] private float delayBetween = 1.5f;

    private Coroutine introRoutine;

    IEnumerator Start()
    {
        Debug.Log("CameraIntroController: Start intro");

        if (FadeManager.Instance == null)
        {
            Debug.LogError("FadeManager.Instance NULL!");
            yield break;
        }

        yield return FadeManager.Instance.FadeIn();
        introRoutine = StartCoroutine(IntroSequence());
        yield return introRoutine;
    }

    IEnumerator IntroSequence()
    {
        if (introCams == null || introCams.Length == 0 || gameplayCam == null)
        {
            Debug.LogError("CameraIntroController: kamera belum lengkap");
            yield break;
        }

        foreach (var cam in introCams)
        {
            SetActiveCamera(cam);
            yield return new WaitForSeconds(delayBetween);
        }

        SetActiveCamera(gameplayCam);
    }

    void SetActiveCamera(CinemachineCamera cam)
    {
        foreach (var c in introCams)
            c.Priority = 0;

        gameplayCam.Priority = 0;
        cam.Priority = 50;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("CameraIntroController: Skip intro");

            if (introRoutine != null)
            {
                StopCoroutine(introRoutine);
                introRoutine = null;
            }

            SetActiveCamera(gameplayCam);
        }
    }
}
