using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class CameraGameController : MonoBehaviour
{
    [Header("Game Cameras (Index = Key)")]
    [SerializeField] private CinemachineCamera[] gameCams;
    Dictionary<KeyCode, int> cameraKeys = new Dictionary<KeyCode, int>()
    {
        { KeyCode.Alpha1, 0 },
        { KeyCode.Alpha2, 1 },
        { KeyCode.Alpha3, 2 },
        { KeyCode.Alpha4, 3 },
        { KeyCode.Alpha5, 4 },
        { KeyCode.Alpha6, 5 },
        { KeyCode.Alpha7, 6 },
        { KeyCode.Alpha8, 7 },
        { KeyCode.Alpha9, 8 },
        { KeyCode.Alpha0, 9 }
    };

    void Start()
    {
        Debug.Log("CameraGameController: Ready");
    }

    void Update()
    {
        HandleChangeView();
    }

    void HandleChangeView()
    {
        foreach (var pair in cameraKeys)
        {
            if (Input.GetKeyDown(pair.Key))
            {
                SetActiveCamera(pair.Value);
                break;
            }
        }
    }

    void SetActiveCamera(int index)
    {
        if (index < 0 || index >= gameCams.Length)
            return;

        foreach (var cam in gameCams)
            cam.Priority = 0;

        gameCams[index].Priority = 50;

        Debug.Log($"Camera switched to index {index}");
    }
}
