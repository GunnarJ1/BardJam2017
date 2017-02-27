﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapeAI : EnemyAI {


    private Material currentMaterial;
    private Material hitMaterial;

    bool canAttack = true;

    protected override void Init()
    {
        base.Init();
        health = 40;
        currentMaterial = GetComponent<Renderer>().material;
        hitMaterial = new Material(currentMaterial);
        hitMaterial.color = Color.red;
        speed = .02f;
    }

    protected override void Attack()
    {
        base.Attack();
        if (canAttack)
        {
            attackablePlayer.DamagePlayer(30);
            Destroy(gameObject);
        }
    }

    protected override void OnAttacked(float damageAmount)
    {
        GetComponent<Renderer>().material = hitMaterial;
        StartCoroutine(ColorReset());
    }

    protected override void OnEnemyDeath()
    {
        int xp = int.Parse(GameManager.instance.playerStats["xp"] as string);
        xp = xp + 20;
        GameManager.instance.playerStats["xp"] = xp + "";
    }

    IEnumerator ColorReset()
    {
        yield return new WaitForSeconds(.2f);
        GetComponent<Renderer>().material = currentMaterial;
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(.2f);
        canAttack = true;
    }


}
