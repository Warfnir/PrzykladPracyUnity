using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform positionToHold;
    public Camera characterCamera;

    private bool isHoldingObject = false;
    private GameObject pickedUpObject = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 9;
        GameObject obj = CastRay(layerMask);
        if (Input.GetButton("Fire1"))
        {
            if (obj)
            {
                if (!isHoldingObject)
                {
                    isHoldingObject = true;
                    pickedUpObject = obj;
                    obj.GetComponent<IInteractionable>().BeginInteraction(transform.gameObject);
                }
            }
        }
        else
        {
            if (isHoldingObject)
            {
                isHoldingObject = false;
                pickedUpObject.GetComponent<IInteractionable>().EndInteraction(transform.gameObject);
                pickedUpObject = null;
            }
        }
    }

    private GameObject CastRay(int layerMask = 0)
    {
        RaycastHit hit;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(characterCamera.transform.position, characterCamera.transform.forward, out hit, 2f, layerMask))
        {
            return hit.collider.gameObject;
        }

        return null;
    }
}
