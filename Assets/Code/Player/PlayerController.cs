using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] PlayerInputManager _playerInputManager;
    [SerializeField] GameObject playerVcam;
    [SerializeField] private Transform _cameraFollowTarget;
    private Quaternion rotation;

    [SerializeField] private Vector3 targetDirection;
    Vector3 movementVector;
    [SerializeField] float speed;
    [SerializeField] float targetRotation;

    private float xRotation;
    private float yRotation;
    private Quaternion rotationCameraDregrees;


    private void Update()
    {
        movementVector = new Vector3(_playerInputManager.movementVector.x, 0, _playerInputManager.movementVector.y);
        targetRotation = 0f;
        if (_playerInputManager.movementVector != Vector2.zero)
        {
            targetRotation = Quaternion.LookRotation(movementVector).eulerAngles.y + playerVcam.transform.rotation.eulerAngles.y;
            rotation = Quaternion.Euler(0, targetRotation, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 20 * Time.deltaTime);
        }
        targetDirection = Quaternion.Euler(0, targetRotation, 0) * Vector3.forward;
        rb.velocity = movementVector * speed;   
    }

    private void LateUpdate()
    {
        CameraRotation();
    }
    void CameraRotation()
    {
        xRotation += _playerInputManager.movementVector.y;
        yRotation += _playerInputManager.movementVector.x;
        xRotation = Mathf.Clamp(xRotation, -30, 70);
        rotationCameraDregrees = Quaternion.Euler(xRotation, yRotation, 0);
        _cameraFollowTarget.rotation = rotationCameraDregrees;
    }

}
