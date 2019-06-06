using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCubeBehaviour : MonoBehaviour, IInteractionable
{
    public float pushStrength = 1f;
    private Rigidbody rigidbody;

    public void BeginInteraction(GameObject initiator)
    {
        //Pushes blue cube in our rotation dirrection
        rigidbody.AddForce(initiator.transform.forward * pushStrength);
    }

    public void EndInteraction(GameObject initiator)
    {
        //Doesn't need one
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

}
