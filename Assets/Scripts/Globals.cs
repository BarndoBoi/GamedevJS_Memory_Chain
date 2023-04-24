using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    //Don't do this in proper projects without a real good reason
    //I'm also too lazy to write singletons for some of these classes, so why not just one big singleton? :DDD

    public static Globals Instance; //Nasty NASTY singleton, don't use out of laziness like me
    public TypedText typedText = GameObject.FindObjectOfType<TypedText>();
    public InspectionScreen inspection; //For piping clicked objects to the UI controller

    //Global variables for each dialogue instance to check
    public enum Seasons //Pretty enum to make up for the ugly singleton
    {
        Spring,
        Summer,
        Fall,
        Winter
    }
    public Seasons Season = Seasons.Winter; //Starting season is in winter

    [SerializeField]
    List<string> springMismatchDialogue = new List<string>();
    [SerializeField]
    List<string> summerMismatchDialogue = new List<string>();
    [SerializeField]
    List<string> fallMismatchDialogue = new List<string>();
    [SerializeField]
    List<string> winterMismatchDialogue = new List<string>();

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
