using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueObject : MonoBehaviour
{

    [SerializeField]
    string nameKey; //We'll use this to check for memory chain dialogues
    [SerializeField]
    string inspectDialogue;
    [SerializeField]
    string memoryChainKey; //The name of the object that can be linked with this one
    [SerializeField]
    string memoryChainDialogue; //The dialogue to type when the linking is done
    public bool inspected = false; //If you haven't inspected something when you go to link you get the inspection dialogue first

    public string GetInspectDialogue()
    {
        if (!inspected)
            inspected = true;
        return inspectDialogue;
    }

    public bool CheckMemoryChain(string key)
    {
        if (key == memoryChainKey)
            return true;
        else return false;
    }

    public string GetMemoryChainDialogue()
    {
        return memoryChainDialogue;
    }

}
