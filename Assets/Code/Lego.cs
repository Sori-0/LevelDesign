using System.Collections;
using UnityEngine;

public class Lego : MonoBehaviour
{
    [SerializeField]GameObject legoDad;
    [SerializeField] GameObject Player;
    [SerializeField] int num;
    [SerializeField] Movement _scriptMovement;

    private void FixedUpdate()
    {
        checkNumOfLegos();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("InteractObject"))
        {
            transform.SetParent(legoDad.transform);
        }
    }

    void checkNumOfLegos()
    {
        num = legoDad.transform.childCount;
        if(num == 2)
        {
            _scriptMovement.BoatState = true;
            StartCoroutine(waitChagePos());
        }
    }

    IEnumerator waitChagePos()
    {
        yield return new WaitForSeconds(0.5f);
        legoDad.transform.SetParent(Player.transform);
    }

}
