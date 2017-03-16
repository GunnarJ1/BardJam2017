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
        actions.Add("level4Entry", new UnityAction(Level4Entry));
    }

    private void Start()
    {

        foreach (string key in actions.Keys)
        {
            EventManager.StartListening(key, actions[key]);
        }

        Debug.Log("OnEnabled listner keyCount: " + actions.Count);
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable listener");
        foreach (string key in actions.Keys)
        {
            EventManager.StopListening(key, actions[key]);
        }
    }

    void Level4Entry()
    {
        text.text = "You found the boss! The evil banana!" + 
            " I mean he is evil so you gotta kill him anyways";
        Invoke("ResetDialogueBox", 10);
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
