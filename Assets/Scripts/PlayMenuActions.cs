using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenuActions : MonoBehaviour
{
    [Header("Scene Settings")]
    public string sceneToLoad = "GameScene";

    public void OnYesClicked()
    {
        FadeManager.Instance.FadeToScene(sceneToLoad);
    }

    public void OnNoClicked()
    {
        Application.Quit();
        // Supaya kelihatan bekerja di Editor
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
