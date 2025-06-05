using UnityEngine;

public class GameInput : MonoBehaviour
{

    public static GameInput Instance { get; private set; }
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        if (Instance == null) Instance = this;

        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}