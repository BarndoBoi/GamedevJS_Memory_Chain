using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectionScreen : MonoBehaviour
{

    private DialogueObject passedDialogue;
    private Sprite passedImage; //Fetch this from the passed DialogueObject's gameobject
    [SerializeField]
    Image inspectionImage; //The image to show in the inspection window

    public void ShowInspectObject(DialogueObject dialogue)
    {
        passedDialogue = dialogue;
        passedImage = dialogue.GetComponent<SpriteRenderer>().sprite; //Nab the sprite off the renderer for showing in our inspection screen
        inspectionImage.sprite = passedImage; //Set the inspection window sprite
    }

    public void OnInspectButton()
    { //Fetch inspection details and feed it to the typer
        Globals.Instance.typedText.StartTyping(passedDialogue.GetInspectDialogue());
    }

    public void OnStartLink()
    { //Call from the linking button and figure out what the hell we're doing for that
        //TODO: The rest of the fucking owl
    }

}
