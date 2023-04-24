using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickObject : MonoBehaviour
{
    //I need to check if you're clicking on the old man as he goes around the inspect screen
    //Otherwise its a scene object and needs to have its stuff piped to the inspect item ui screen

    [SerializeField] private bool isOldMan; //If this click object is the old man, we handle that case separately

    void OnClick()
    {
        if (isOldMan)
        { //Handle old man cases here later
        }

        else
        { //Yeet our object over to the UI screen if it isn't the old man
            Globals.Instance.inspection.ShowInspectObject(GetComponent<DialogueObject>()); 
        }
    }

}
