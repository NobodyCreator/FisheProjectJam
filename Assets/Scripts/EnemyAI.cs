using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public Transform Player;
    public float detectionRadius = 5f; // ze enemy sees
    public float attackInterval = 3f;// ze enemy reloads
    public int damage = 10;// ze enemy FAKS Yyou
    private bool isPlayerInRange = false;
    private bool isAttacking = false;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);
        if (distanceToPlayer <= detectionRadius)
        {
            isPlayerInRange = true;
            FlipSprite();
            if (!isAttacking)
            {
                StartCoroutine(AttackPlayer());
            }
        }
        else
        {
            isPlayerInRange = false;
        }
    }

    void FlipSprite()
    {
        if (Player.position.x < transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    IEnumerator AttackPlayer()
    {
        isAttacking = true;

        while (isPlayerInRange)
        {
            Player.GetComponent<Health>().TakeDamage(damage);
            yield return new WaitForSeconds(attackInterval);
        }
        isAttacking = false;
    }
}
