using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool isOpen = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (!isOpen)
        {
            animator.SetTrigger("OpenDoor");
            isOpen = true;
            Debug.Log("DoorController: Door opened");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (isOpen)
        {
            animator.SetTrigger("CloseDoor");
            isOpen = false;
            Debug.Log("DoorController: Door closed");
        }
    }
}
