using UnityEngine;
using Photon.Pun;

public class InputManager : MonoBehaviourPun
{
    private PlayerInput playerInput;
    private PlayerMotor motor;
    private PlayerLook look;
    private PlayerInput.OnFootActions onFoot;

    public PlayerInput.OnFootActions GetOnFootActions()
    {
        return onFoot;
    }

    private void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
    }

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        if (photonView.IsMine == false)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
        }
    }

    private void LateUpdate()
    {
        if (photonView.IsMine)
        {
            look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
        }
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
