using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    Quaternion cameraRotation;
    Vector3 cameraVector;
    [SerializeField] float speedCameraRotation;
    
    private void FixedUpdate()
    {
        cameraRotation.eulerAngles += cameraVector.normalized * speedCameraRotation;
        transform.rotation = cameraRotation;
    }

    public void OnMoveCamera(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            cameraVector.y = value.ReadValue<Vector2>().x;
            cameraVector.x -= value.ReadValue<Vector2>().y;

        }
        else if (value.canceled)
        {
            cameraVector = Vector2.zero;
        }
    }
}
