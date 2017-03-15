using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
// Stop programming super late at night
// Dialogue system now works fully
[RequireComponent (typeof(Text))]
public class DialogueListener : MonoBehaviour {

    private Text text;
    private Dictionary<string, UnityAction> actions = new Dictionary<string, UnityAction>();
    
    private void Awake()
    {
        text = GetComponent<Text>();
        ResetDialogueBox();
        actions.Add("startGame", new UnityAction(StartGameDialogue));
        actions.Add("onDeath", new UnityAction(OnDeath));

    }

    private void Start()
    {

        Debug.Log("OnEnabled listner keyCount: " + actions.Count);
        EventManager.StartListening("startGame", actions["startGame"]);
        EventManager.StartListening("onDeath", actions["onDeath"]);
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable listener");
        EventManager.StopListening("startGame", actions["startGame"]);
        EventManager.StopListening("onDeath", actions["onDeath"]);
    }

    void OnDeath()
    {
        text.text = "OH NO YOU DIED!";
        Invoke("ResetDialogueBox", 10);
    }

    void StartGameDialogue()
    {
        Debug.Log("This works foo");

        text.text = "Welcome! Please shoot all the fruits and gain thier" +
            " life essence to rebuild civilization for JamKind";
        Invoke("ResetDialogueBox", 10);
    }

    void ResetDialogueBox()
    {
        text.text = "";
    }

}
