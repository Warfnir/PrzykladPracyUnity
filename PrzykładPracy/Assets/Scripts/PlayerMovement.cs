using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Public variables describing movement
    public float gravity = 0.1f;
    public float movementSpeed = 1.0f;
    public float rotationSpeed = 1.0f;

    //Private player's components
    private CharacterController characterController;
    private Camera characterCamera;

    //Private variables for movement
    private float Ymovement = 0f;
    private bool touchingGround = true;
   
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        characterController = GetComponent<CharacterController>();
        characterCamera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input for jumping
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        //Applying gravity after jump.
        if(!touchingGround)
        {
            Ymovement -= gravity;
        }

        //Applying movement in axisX and axisZ
        Vector3 motion = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        motion = transform.TransformDirection(motion);
        motion.y = Ymovement;   //Adding Y movement
        characterController.Move(motion * Time.deltaTime * movementSpeed);

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Resets jumping on collision with ground
        if (hit.collider.tag == "Ground")
        {
            touchingGround = true;
            Ymovement = 0f;
        }
    }

    //Jumping function, applying force in Y axis.
    private void Jump()
    {
        if(touchingGround)
        {
            touchingGround = false;
            Ymovement += 3f;
        }
    }
}
