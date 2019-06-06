using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreemCubeBehaviour : MonoBehaviour, IInteractionable
{
    public float jumpForce = 1f;
    public float pushForce = 1f;
    private Rigidbody rigidbody;

    public void BeginInteraction(GameObject initiator)
    {
        //Cube jumps opposite to player's dirrection
        Vector3 force = initiator.transform.forward * pushForce;
        force.y = jumpForce;
        rigidbody.AddForce(force);
    }

    public void EndInteraction(GameObject initiator)
    {
        //Dont need one
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

}
