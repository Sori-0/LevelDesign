using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class Interact : MonoBehaviour
{
    [SerializeField] Movement _movementScrpit;

    private void FixedUpdate()
    {
        SomeThingInHand();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("InteractObject") && _movementScrpit.IsInteracting == true)
        {
            other.transform.SetParent(transform, true);
        }
    }

    void SomeThingInHand()
    {
        if(transform.childCount != 0 && _movementScrpit.IsInteracting == false)
        {
            transform.DetachChildren();
        }
    }

}
