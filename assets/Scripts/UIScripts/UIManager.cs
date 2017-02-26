using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

    [SerializeField]
    private Text health;
    [SerializeField]
    private Text xp;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        health.text = "Health: " + (GameManager.instance.playerStats["health"] as string);
        xp.text = "XP: " + (GameManager.instance.playerStats["xp"] as string);
	}
}
