using Unity.VisualScripting;
using UnityEngine;

public class SleepController : MonoBehaviour
{
    private Animator playerAnim;
    private bool needSleep = false;

    public void OnClicked()
    {
        Debug.Log("SleepController: Sleep button clicked");
        needSleep = !needSleep;
        timeToSleep();
    }

    void timeToSleep()
    {
        if (needSleep)
        {
            playerAnim = GameObject.FindWithTag("Player").GetComponentInChildren<Animator>();
            if (playerAnim != null)
            {
                playerAnim.SetBool("isSleeping", true);
                Debug.Log("SleepController: Player is sleeping");
            }
        }
        else
        {
            if (playerAnim != null)
            {
                playerAnim.SetBool("isSleeping", false);
                bool isSleeping = playerAnim.GetBool("isSleeping");
                Debug.Log($"SleepController: Player woke up {isSleeping}");
            }
        }
    }
}
