using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera playerCamera;
    [SerializeField] private float xRotation = 0f;
    [SerializeField] private float xSensitivity = 30f;
    [SerializeField] private float ySensitivity = 30f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -20f, 20f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate((mouseX * Time.deltaTime) * xSensitivity * Vector3.up);
    }
}
