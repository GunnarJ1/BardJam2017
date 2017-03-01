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
        playerStats.Add("spawners", "0");
    }
	
	// Update is called once per frame
	void Update () {

        //First level
		if ((playerStats["level"] as string) == "1")
        {
            if (int.Parse((playerStats["spawners"] as string)) >= 2)
            {
                playerStats["level"] = "2";
                SceneManager.LoadScene(1);
                playerStats["spawners"] = "0";
            }
            //Second level
        } else if ((playerStats["level"] as string) == "2")
        {
            if (int.Parse((playerStats["spawners"] as string)) >= 2)
            {
                playerStats["level"] = "3";
                SceneManager.LoadScene(2);
                playerStats["spawners"] = "0";
            }
            //Third level
        } else if ((playerStats["level"] as string) == "3")
        {
            if (int.Parse((playerStats["spawners"] as string)) >= 1)
            {
                playerStats["level"] = "4";
                SceneManager.LoadScene(3);
                playerStats["spawners"] = "0";
            }

        }
    }

    private void LateUpdate()
    {
        if (int.Parse(playerStats["health"] as string) <= 0)
        {
            ResetGame();
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

}
