using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypedText : MonoBehaviour
{
    [SerializeField]
    float typeTime; //This must elapse before the next character is written
    [SerializeField]
    TMPro.TMP_Text TextComponent; //The target component to write the characters into
    [SerializeField]
    RectTransform textParent; //For hiding and showing the dialogue box

    //This delegate gets called after the user skips the autotyping or it completes normally
    public delegate void OnTypingDone();
    public OnTypingDone onTypingDone;

    public string TestString; //Only for testing purposes

    private string textToWrite;
    private IEnumerator activeCoroutine;
    private bool stillTyping = true;

    private void Awake()
    {
        onTypingDone = new OnTypingDone(OnTextFinished);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (stillTyping) {
                StopCoroutine(activeCoroutine);
                TextComponent.text = textToWrite;
                if (onTypingDone != null)
                    onTypingDone(); //Call the delegate if they skip the typing
            }
            else
            { //If you aren't typing then the window is just chilling there waiting to be closed for slow readers and the impaired

            }
        }
    }

    public void StartTyping(string text)
    {
        //Clear the existing text before we start writing and display the component's parent object
        stillTyping = true;
        this.gameObject.SetActive(true);
        TextComponent.text = "";
        textToWrite = text;
        activeCoroutine = WriteText();
        StartCoroutine(activeCoroutine);
    }

    private IEnumerator WriteText()
    {
        for (int i = 0; i < textToWrite.Length; i++)
        {
            TextComponent.text = string.Concat(TextComponent.text, textToWrite[i]);
            yield return new WaitForSeconds(typeTime); //Wait until time has elapsed before writing the next
        }

    }

    private void OnTextFinished()
    { //This is where I would like to implement the click to close window behavior
        stillTyping = false;
    }

    private void OnCleanup()
    { //As far as I know, cleaning up only involves hiding the window for now, and possibly targeting the inspection window
        this.gameObject.SetActive(false);
    }
}
