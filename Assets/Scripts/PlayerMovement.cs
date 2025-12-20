using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float gravity = -9.81f;

    [Header("References")]
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Animator animator;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (!animator)
            animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        bool isWatching = animator.GetBool("isWatching");
        bool isSleeping = animator.GetBool("isSleeping");
        bool isNodding = animator.GetBool("isNodding");
        bool isJumping = animator.GetBool("isJumping");
        if (isWatching || isSleeping || isNodding || isJumping)
        {
            animator.SetBool("isWalking", false);
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 inputDir = new Vector3(h, 0, v);
        bool isMoving = inputDir.magnitude > 0.1f;

        Vector3 move = Vector3.zero;

        if (isMoving)
        {
            Vector3 camForward = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;

            camForward.y = 0;
            camRight.y = 0;

            Vector3 moveDir = camForward.normalized * v + camRight.normalized * h;
            move = moveDir * moveSpeed;

            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRot,
                rotationSpeed * Time.deltaTime
            );
        }

        if (controller.isGrounded)
        {
            if (velocity.y < 0)
                velocity.y = -2f;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        Vector3 finalMove = move + velocity;
        controller.Move(finalMove * Time.deltaTime);

        animator.SetBool("isWalking", isMoving);
    }

    public void OnNodFinished()
    {
        Debug.Log("PlayerAnimationEvents: Nodding finished");
        animator.SetBool("isNodding", false);
    }
}
