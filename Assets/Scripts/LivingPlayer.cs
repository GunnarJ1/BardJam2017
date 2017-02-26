using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingPlayer : MonoBehaviour {

    private float health = 100;

    public void DamagePlayer(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
            gameObject.SetActive(false);
    }

}
