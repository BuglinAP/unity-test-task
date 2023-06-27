using UnityEngine;
using Photon.Pun;

public class PlayerInteract : MonoBehaviourPun
{
    private Camera playerCamera;
    private PlayerUI playerUI;
    private InputManager inputManager;
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask mask;

    void Start()
    {
        playerCamera = GetComponent<PlayerLook>().playerCamera;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        if (photonView.IsMine == false)
        {
            return;
        }
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promtMessage);
                if (inputManager.GetOnFootActions().Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
