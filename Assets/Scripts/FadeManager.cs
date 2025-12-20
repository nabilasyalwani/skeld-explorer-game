using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance;

    public CanvasGroup fadeCanvas;
    public float fadeDuration = 1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Screen.fullScreen = false;
        } else if (Input.GetKeyDown(KeyCode.F11))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoad(sceneName));
    }

    public IEnumerator FadeIn()
    {
        fadeCanvas.alpha = 1;

        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeCanvas.alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            yield return null;
        }

        fadeCanvas.alpha = 0;
        fadeCanvas.blocksRaycasts = false;
    }

    public IEnumerator FadeOutAndLoad(string sceneName)
    {
        fadeCanvas.blocksRaycasts = true;

        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeCanvas.alpha = Mathf.Lerp(0, 1, t / fadeDuration);
            yield return null;
        }

        fadeCanvas.alpha = 1;
        SceneManager.LoadScene(sceneName);
    }
}
