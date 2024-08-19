using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float groundDist;


    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;

    public Health health;

    public float replenishRange = 100f; // Range within which tank replenishes shit
    public int replenishAmount = 3;//amount to replenish
    public KeyCode replenishKey = KeyCode.E;// press EEEEEEEEEEEEEEE
    public float holdDuration = 2f;

    private float holdTimer = 0f;//toimer that tracks lenght of button held

    public float attackRange = 4f;//HAHA KILLLL
    public int attackDamage = 10;
    public LayerMask enemyLayer;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        health = gameObject.GetComponent<Health>();
    }


    void Update()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if (hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
        }


        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //testing
        //Debug.Log("Horizontal Input: " + x);
        //Debug.Log("Vertical Input: " + y);


        Vector3 moveDir = new Vector3(x, 0, y);
        rb.velocity = moveDir * speed;

        //flipping based on the position we are moving
        if (x != 0 && x < 0)
        {
            sr.flipX = true;
        }
        else if (x != 0 && x > 0)
        {
            sr.flipX = false;
        }

        if (Input.GetKey(replenishKey))
        {
            holdTimer += Time.deltaTime;
            Debug.Log("button " + replenishKey + " has been pressed!");

            if (holdTimer >= holdDuration)
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, replenishRange);
                foreach (var collide in hitColliders)
                {
                    if (collide.CompareTag("ReplenishObject"))
                    {
                        ReplenishObject replenishObject = collide.GetComponent<ReplenishObject>();
                        if (replenishObject != null && !replenishObject.IsUsed)

                        {
                            health.TakeElectronics(replenishAmount);
                            Debug.Log("Electronics Replenished");
                            replenishObject.Use();//object = used
                            holdTimer = 0f;
                            break;
                        }
                    }
                    else if (collide.CompareTag("EnemyObject"))
                    {

                        npcController humanObject = collide.GetComponent<npcController>();

                        if(humanObject != null && humanObject.suckable)
                        {

                            health.takeHuman(1);
                            Debug.Log("Human Absorbed");
                            Destroy(humanObject.gameObject);
                            holdTimer = 0f;
                            break;

                        }

                    }
                }
            }
        }
        else
        {
            holdTimer = 0f; //reset timer if key not held
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            if ((sr.flipX && enemy.transform.position.x < transform.position.x) ||
                (!sr.flipX && enemy.transform.position.x > transform.position.x))
            {
                enemy.GetComponent<Health>().TakeDamage(attackDamage);
                Debug.Log("enemy atTAco");
            }
        }
    }


    public void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }
}
