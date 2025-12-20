using Unity.VisualScripting;
using UnityEngine;

public class WatchController : MonoBehaviour
{
    private Animator playerAnim;
    private bool watchMonitor = false;

    public void OnClicked()
    {
        Debug.Log("WatchController: Monitor Activated");
        watchMonitor = !watchMonitor;
        monitoringTV();
    }

    void monitoringTV()
    {
        if (watchMonitor)
        {
            playerAnim = GameObject.FindWithTag("Player").GetComponentInChildren<Animator>();
            if (playerAnim != null)
            {
                playerAnim.SetBool("isWatching", true);
                Debug.Log("WatchController: Player is monitoring");
            }
        }
        else
        {
            if (playerAnim != null)
            {
                playerAnim.SetBool("isWatching", false);
                bool isWatching = playerAnim.GetBool("isWatching");
                Debug.Log($"WatchController: Player monitoring {isWatching}");
            }
        }
    }
}
