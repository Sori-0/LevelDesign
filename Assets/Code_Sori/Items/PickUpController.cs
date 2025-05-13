using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpController : MonoBehaviour
{
    [SerializeField] private Rigidbody itemRigidBody;
    [SerializeField] private Collider itemCollider;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform container;

    [SerializeField] private float pickUpRange;
    [SerializeField] private float dropForwardForce;
    [SerializeField] private float dropUpwardForce;

    [SerializeField] PlayerInputManager _playerInputManager;

    public static bool slotFull;
    public bool equipped;

    #region RunTimeVariables
    Vector3 distanceToPlayer;
    #endregion

    void Start()
    {
        if (!equipped)
        {
            itemRigidBody.isKinematic = false;
            itemCollider.isTrigger = false;
        }
        else
        {
            itemRigidBody.isKinematic = true;
            itemCollider.isTrigger = true;
            slotFull = true;
        }
    }
    private void Update()
    {
        distanceToPlayer = playerTransform.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.magenta;
            if (_playerInputManager.isInteracting == true && !slotFull)//No usar
            {
                PickUp();
            }
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        if (equipped && _playerInputManager.isInteracting == false)//No usar
        {
            Drop();
        }
    }
    void PickUp()
    {
        equipped = true;
        slotFull = true;
        //gameObject.GetComponent<Renderer>().material.color = Color.white;

        transform.SetParent(container);
        //transform.localPosition = Vector3.zero;
        //transform.localRotation = Quaternion.Euler(Vector3.zero);
        //transform.localScale = Vector3.one;

        itemRigidBody.isKinematic = true;
        itemCollider.isTrigger = true;

        if(_playerInputManager.isInteracting == true)
        {
           
        }
    }
    void Drop()
    {
        equipped = false;
        slotFull = false;
        //StartCoroutine(_playerInputManager.waitInteract());

        transform.SetParent(null);

        itemRigidBody.isKinematic = false;
        itemCollider.isTrigger = false;

        float random = Random.Range(-1f, 1f);
        itemRigidBody.AddTorque(new Vector3(random, random, random) * 10);
    }


}
