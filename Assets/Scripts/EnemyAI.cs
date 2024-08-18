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
  




    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);
        if (distanceToPlayer <= detectionRadius)
        {
            isPlayerInRange = true;
            FacePlayer();
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

    void FacePlayer()
    {
        Vector3 direction = Player.position - transform.position;
        direction.z = 1; //if 0 then he becomes a fucking statue if 1 he goes insane
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);//maybe 
    }

    IEnumerator AttackPlayer()
    {
        isAttacking = true;

        while(isPlayerInRange)
        {
            Player.GetComponent<Health>().TakeDamage(damage); //gimme the healthussy
            yield return new WaitForSeconds(attackInterval);
        }
        isAttacking = false;
    }
}
