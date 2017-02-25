using System.Collections;
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
        Debug.Log(damageAmount);
        GetComponent<Renderer>().material = hitMaterial;
        StartCoroutine(ColorReset());
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
