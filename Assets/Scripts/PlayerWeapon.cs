using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    [SerializeField]
    private Animator animator;

    private void Awake()
    {

    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(ray, out hit, 1000))
            {
            
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    EnemyAI enemy = hit.collider.gameObject.GetComponent<EnemyAI>();
                    enemy.DamageEnemy(10);
                }
            }
            animator.SetBool("isShooting", true);

            StartCoroutine(ResetAnimator());
        }
    }

    IEnumerator ResetAnimator()
    {
        yield return new WaitForSeconds(.008f);
        animator.SetBool("isShooting", false);
    }

}
