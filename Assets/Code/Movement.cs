using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using System.Collections;





public class Movement : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] Rigidbody rb;
    Vector3 movementVector;
    [SerializeField] float jumpForce;

    [SerializeField] GameObject XiolfonoObject;

    [SerializeField] Transform boatPos;
    [SerializeField] Transform xilofonoPos;

    [SerializeField] bool grounded;
    [SerializeField] float jumpCuldown;

    [SerializeField] bool interact;

    [SerializeField] Transform cameraTransform;

    [SerializeField] GameObject door;

    [SerializeField] bool Boat;
    bool xilofono = false;
    bool changeboat = false;
    bool changexilfono = false;

    //Quaternion cameraRotation;
    //Vector3 cameraVector;
    //[SerializeField] float speedCameraRotation;

    [SerializeField] bool checkGround;

    void Start()
    {
        movementVector = Vector3.zero;
        Boat = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = movementVector.normalized * speed;
        OnBoat();
        OnXilofono();
        IsInGround();
        //cameraRotation.eulerAngles += cameraVector.normalized * speedCameraRotation;
        //transform.rotation = cameraRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Xilofono") && interact == true) {
            Debug.Log("Hijo de xilofono");
            xilofono = true;
            StartCoroutine(waitChangePos());
        }

        if (other.gameObject.CompareTag("CatapultaPieces"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("BallsPool") && Boat == false)
        {
            gameObject.SetActive(false);
        }
    }

    void OnBoat()
    {
        
        if (Boat == true && changeboat == false)
        {
            transform.position = boatPos.position;
            changeboat = true;
        }
    }
    void OnXilofono()
    {

        if (xilofono == true && changexilfono == false)
        {
            transform.position = xilofonoPos.position;
            changexilfono = true;
        }
    }

    #region inputActions
    public void OnMovement(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            movementVector = (cameraTransform.forward * value.ReadValue<Vector2>().y) + (cameraTransform.right * value.ReadValue<Vector2>().x);
            
        }
        else if (value.canceled)
        {
            movementVector = Vector3.zero;
        }
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.performed && jumpCuldown == 0)
        {
            Debug.Log("Saltando");
            grounded = false;
            jumpCuldown = 1;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void OnInteract(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            interact = true;
        }
        else if (value.canceled)
        {
            interact = false;
        }
    }

     void IsInGround()
    {
        if (grounded == true)
        {
            Debug.Log("Estoy en piso");
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            jumpCuldown = 0;
           
        }
        else if(grounded == false)
        {
            Debug.Log("No estoy en piso");
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    #endregion

    #region getters and Setters
    public bool GroundState
    {
        set { grounded = value; }
    }
    public bool IsInteracting
    {
        get { return interact; }
    }
    public bool BoatState
    {
        set { Boat = value; }
    }

    public bool xilofonoState
    {
        set { xilofono = value; }
    }
    #endregion

    IEnumerator waitChangePos()
    {
        yield return new WaitForSeconds(0.5f);
        XiolfonoObject.transform.SetParent(transform, true);
        door.SetActive(false);
        speed += 1;
    }

}
