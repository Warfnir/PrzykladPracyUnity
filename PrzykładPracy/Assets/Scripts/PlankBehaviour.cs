using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlankBehaviour : MonoBehaviour, IInteractionable
{
    public string textToDisplay = "";
    //Text in player's canvas
    public Text textUI;    

    private bool isBeingDisplayed = false;


    public void BeginInteraction(GameObject initiator)
    {
        //Displays text
        if(!isBeingDisplayed)
        {
            isBeingDisplayed = true;
            textUI.text = textToDisplay;
            textUI.gameObject.SetActive(true);
        }
    }

    public void EndInteraction(GameObject initiator)
    {
        //Turn of the text
        isBeingDisplayed = false;
        textUI.gameObject.SetActive(false);
    }

}
