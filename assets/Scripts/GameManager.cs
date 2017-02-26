using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    public Dictionary<string, object> playerStats = new Dictionary<string, object>();

    public static GameManager instance = null;

    

    private void Awake()
    {
        //Creates singleton pattern
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        playerStats.Add("health", "100");
        playerStats.Add("xp", "0");
        playerStats.Add("level", "1");
    }
	
	// Update is called once per frame
	void Update () {

        //Changes levels
		if ((playerStats["level"] as string) == "1")
        {
            if (int.Parse((playerStats["xp"] as string)) >= 180)
            {
                playerStats["level"] = "2";
                SceneManager.LoadScene(1);
            }
        } else if ((playerStats["level"] as string) == "1")
        {
        }
	}
}
