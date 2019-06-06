using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractionable
{
    //Used when player begins interactions with object
    void BeginInteraction(GameObject initiator);


    //Used when player ends interactions with object
    void EndInteraction(GameObject initiator);
}
