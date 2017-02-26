using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [Header("Enemy Information")]
    [SerializeField]
    protected StateID currentState = StateID.Idle;
    [SerializeField]
    protected float health = 100;
    [Header("Player Information")]
    [SerializeField]
    private string playerTag = "Player";
    protected GameObject player;

    private Quaternion tempRotation;
    private Vector3 tempPosition;

    protected float speed = .005f;
    protected bool isAttacking = false;
    protected LivingPlayer attackablePlayer;

    public enum StateID
    {
        Follow,
        Attack,
        Idle
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        Init();
    }

    private void Update()
    {
        //Runs state method based on which state is in
        SwitchState(currentState);

    }

    protected virtual void Init()
    {

    }

    protected virtual void OnAttacked(float damageAmount)
    {

    }
    
    //Follows player around
    protected virtual void Follow()
    {
        tempPosition = transform.position;
        tempPosition = Vector3.Lerp(tempPosition, player.transform.position, speed);
        tempPosition.y = transform.position.y;
        transform.position = tempPosition;
        if (isAttacking)
            currentState = StateID.Attack;
    }


    protected virtual void Attack()
    {
        if (!isAttacking)
            currentState = StateID.Follow;

    }

    protected virtual void Idle()
    {

    }

    private void SwitchState(StateID state)
    {
        switch (state)
        {
            case StateID.Follow:
                Follow();
                break;
            case StateID.Attack:
                Attack();
                break;
            case StateID.Idle:
                Idle();
                break;
            default:
                Idle();
                break;
        }
    }

    public void DamageEnemy(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
            Destroy(gameObject);
        OnAttacked(damageAmount);
    }

    public float GetHealth()
    {
        return health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            attackablePlayer = other.gameObject.GetComponent<LivingPlayer>();
            isAttacking = true;
            Debug.Log("Found player!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isAttacking = false;
        }
    }

}