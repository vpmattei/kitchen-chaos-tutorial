using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 inputVector;

    [SerializeField] private float moveSpeed = .05f;
    [SerializeField] private float rotateSpeed = 10f;

    [SerializeField] private Animator animator;

    private bool isWalking = false;

    private void Update()
    {
        inputVector = GameInput.Instance.GetMovementVectorNormalized();
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirection, moveDistance);

        if (!canMove)
        {
            // Cannot move towards moveDirection

            // Attempt only X movement
            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirectionX, moveDistance);
            if (canMove)
            {
                // Moves only in the X axis
                moveDirection = moveDirectionX;
            }
            else
            {
                // Cannot move in the X axis

                // Attempt only Y movement
                Vector3 moveDirectionZ = new Vector3(0, 0, moveDirection.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirectionZ, moveDistance);
                if (canMove)
                {
                    // Moves only in the Y axis
                    moveDirection = moveDirectionZ;
                }
                else
                {
                    // Does not move
                }
            }
        }
        if (canMove)
        {
            transform.position += moveDirection * moveDistance;
        }

        isWalking = moveDirection != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
