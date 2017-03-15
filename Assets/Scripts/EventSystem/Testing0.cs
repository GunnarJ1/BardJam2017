using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Testing0 : MonoBehaviour {

    private UnityAction someListner;

    private void Awake()
    {
        someListner = new UnityAction(SomeFunction);
    }

    private void OnEnable()
    {
        EventManager.StartListening("test", someListner);
    }

    private void OnDisable()
    {
        EventManager.StartListening("test", someListner);
    }

    void SomeFunction()
    {
        Debug.Log("Some function was called.");
    }

}
