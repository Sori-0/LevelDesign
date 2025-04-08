using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstaclesPool : MonoBehaviour
{
    [SerializeField] float firstPos;
    [SerializeField] float secondPos;
    [SerializeField] float timeToPosition;
    [SerializeField] float newPosition;
    [SerializeField] float time;
    bool another;
    [SerializeField] Vector3 movementVector;
    private void Start()
    {
        another = false;
        movementVector = transform.position;
    }
    private void FixedUpdate()
    {
        MoveTox(firstPos, secondPos);
    }


    void MoveTox(float _firstPos, float _secondPos)
    {
        newPosition = firstPos;
        time += Time.fixedDeltaTime;
        movementVector.x = Mathf.Lerp(_firstPos, _secondPos, time / timeToPosition);
        transform.position = movementVector;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SecondPosition"))
        {
            Debug.Log("En camino a first");
            time = 0;
            firstPos = secondPos;
            secondPos = newPosition;
            another = true;
        }
        if (other.gameObject.CompareTag("FirstPosition") && another == true)
        {
            Debug.Log("En camino a second");
            time = 0;
            firstPos = secondPos;
            secondPos = newPosition;
            another = false;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
        }

    }
}
