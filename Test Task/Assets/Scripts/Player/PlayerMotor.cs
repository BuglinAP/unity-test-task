using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float movementSpeed = 6f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(movementSpeed * Time.deltaTime * transform.TransformDirection(moveDirection));
    }
}
