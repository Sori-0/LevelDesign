using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public Vector2 movementVector;
    public Vector2 directionLook;

    #region inputActions
    public void OnMove(InputValue value)
    {
        movementVector = value.Get<Vector2>();
    }
    void OnLook(InputValue value)
    {
        directionLook = value.Get<Vector2>();
    }


    //public void OnJump(InputAction.CallbackContext value)
    //{
    //    if (value.performed && jumpCuldown == 0)
    //    {
    //        Debug.Log("Saltando");
    //        grounded = false;
    //        jumpCuldown = 1;
    //        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //    }
    //}

    //public void OnInteract(InputAction.CallbackContext value)
    //{
    //    if (value.performed)
    //    {
    //        interact = true;
    //    }
    //    else if (value.canceled)
    //    {
    //        interact = false;
    //    }
    //}

    //void IsInGround()
    //{
    //    if (grounded == true)
    //    {
    //        Debug.Log("Estoy en piso");
    //        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    //        jumpCuldown = 0;

    //    }
    //    else if (grounded == false)
    //    {
    //        Debug.Log("No estoy en piso");
    //        rb.constraints = RigidbodyConstraints.FreezeRotation;
    //    }
    //}

    #endregion
}
