using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public Vector2 movementVector;
    public Vector2 directionLook;

    [SerializeField] public float isJumping;
    [SerializeField] float jumpReset;

    [SerializeField] public bool isInteracting;
    [SerializeField] float intereactReset;

    #region inputActions
    public void OnMove(InputValue value)
    {
        movementVector = value.Get<Vector2>();
    }
    void OnLook(InputValue value)
    {
        directionLook = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        isJumping = value.Get<float>();
        StartCoroutine(waitJump());
    }

    void OnInteract(InputValue value)
    {
        if (value.isPressed && isInteracting == true)
        {
            isInteracting = false;
        }
        else if(value.isPressed && isInteracting == false)
        {
            isInteracting = true;
        }
    }


    #endregion

    IEnumerator waitJump()
    {
        yield return new WaitForSeconds(jumpReset);
        isJumping = 0f;
    }

    public IEnumerator waitInteract()
    {
        yield return new WaitForSeconds(intereactReset);
        isInteracting = false;
    }

}
