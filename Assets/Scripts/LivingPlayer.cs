using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingPlayer : MonoBehaviour {

    private float health = 100;

    public void DamagePlayer(float damageAmount)
    {
       // health -= damageAmount;
        GameManager.instance.playerStats["health"] = health + ""; 
    }

    private void OnDisable()
    {
    }

}
