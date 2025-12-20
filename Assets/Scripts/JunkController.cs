using Unity.Cinemachine;
using UnityEngine;

public class JunkController : MonoBehaviour
{
    private Animator playerAnim;

    private void Update()
    {
        if (playerAnim != null && !playerAnim.GetBool("isNodding"))
        {
            Destroy(gameObject);
            playerAnim = null;
            Debug.Log("JunkController: Player animator is reset");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerAnim = other.GetComponentInChildren<Animator>();
            if (playerAnim != null)
            {
                playerAnim.SetBool("isNodding", true);
                Debug.Log("JunkController: Player is nodding");
            }
        }
    }
}
