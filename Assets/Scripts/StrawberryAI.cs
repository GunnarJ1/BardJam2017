﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawberryAI : EnemyAI {

    private Material currentMaterial;
    private Material hitMaterial;

    bool canAttack = true;

    protected override void Init()
    {
        base.Init();
        health = 25;
        currentMaterial = GetComponent<Renderer>().material;
        hitMaterial = new Material(currentMaterial);
        hitMaterial.color = Color.red;
        speed = .01f;
    }

    protected override void Attack()
    {
        base.Attack();
        if (canAttack)
        {
            attackablePlayer.DamagePlayer(10);
            canAttack = false;
            StartCoroutine(ResetAttack());
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
        xp += 10;
        GameManager.instance.playerStats["xp"] = xp + "";
        EventManager.TriggerEvent("test");
    }

    IEnumerator ColorReset()
    {
        yield return new WaitForSeconds(.2f);
        GetComponent<Renderer>().material = currentMaterial;
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(.5f);
        canAttack = true;
    }

}
