using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] Movement _movementScript;
    [SerializeField] bool ground;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            ground = true;
            _movementScript.GroundState = ground;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            ground = false;
            _movementScript.GroundState = ground;
        }
    }

    
}
