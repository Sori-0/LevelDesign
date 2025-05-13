using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum interactEvents
{
    Xilofono,
    Lego,
}


public class InteractController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float intereactRange;
    [SerializeField] private interactEvents _currentEvent;

    public static bool _interacted;
    public bool _interact;


    [SerializeField] PlayerInputManager _playerInputManager;

    #region RunTimeVariables
    Vector3 distanceToPlayer;
    #endregion


    private void Update()
    {
        distanceToPlayer = playerTransform.position - transform.position;
        if (!_interact && distanceToPlayer.magnitude <= intereactRange)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            if (_playerInputManager.isInteracting)
            {
                Debug.Log("Interectuando");
                switch (_currentEvent)
                {
                    case interactEvents.Xilofono:
                        Xilofono _scriptXilofono = transform.GetComponent<Xilofono>();
                        _scriptXilofono.XilofonoStart();
                        break;
                    case interactEvents.Lego:
                        Lego _scriptLego = transform.GetComponent<Lego>();
                        _scriptLego.LegoStart();
                        break;
                }
                StartCoroutine(_playerInputManager.waitInteract());
            }
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }

}
