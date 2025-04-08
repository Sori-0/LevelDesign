using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xilofono : MonoBehaviour
{
    [SerializeField] Movement _scriptMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EndRace"))
        {
            Debug.Log("Adios");
            gameObject.SetActive(false);
            _scriptMovement.speed -= 1;
        }
    }
}
