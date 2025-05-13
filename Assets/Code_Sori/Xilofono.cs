using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xilofono : MonoBehaviour
{
    [SerializeField] Movement _scriptMovement;
    [SerializeField] Transform _movePlayerPosition;
    [SerializeField] GameObject _Player; 


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EndRace"))
        {
            Debug.Log("Adios");
            gameObject.SetActive(false);
            _scriptMovement.speed -= 1;
        }
    }

    public void CambiePosicion()
    {
        Debug.Log("Funciona");
    }

    public void XilofonoStart()
    {
        _Player.transform.position = _movePlayerPosition.position;
        gameObject.transform.SetParent(_Player.transform, true);
    }
}
