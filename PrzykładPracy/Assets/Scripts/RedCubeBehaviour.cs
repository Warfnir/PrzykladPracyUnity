using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCubeBehaviour : MonoBehaviour, IInteractionable
{
    private bool isBeingHold = false;
    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    //Pick up item by joining it to player
    public void BeginInteraction(GameObject initiator)
    {
        if (!isBeingHold)
        {
            transform.parent = initiator.transform.Find("ItemHolder");
            transform.localPosition = new Vector3(0, 0, 0);
            rigidbody.useGravity = false;
            isBeingHold = true;
        }
    }

    //Drop item by setting parrent to null
    public void EndInteraction(GameObject initiator)
    {
        isBeingHold = false;
        rigidbody.useGravity = true;
        transform.parent = null;
    }

}
