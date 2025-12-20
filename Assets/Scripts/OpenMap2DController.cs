using UnityEngine;

public class OpenMap2DController : MonoBehaviour
{
    [Header("Open 2D Map")]
    [SerializeField] private CanvasGroup openMap;
    private bool isMapOpen = false;

    public void OnClicked()
    {
        Debug.Log("OpenMap2DController: Map 2D clicked!");
        isMapOpen = !isMapOpen;
        openMap.gameObject.SetActive(isMapOpen);
    }
}
