using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcController : MonoBehaviour
{

    public bool isEnemy, suckable, isDead;

    int health;

    // Start is called before the first frame update
    void Start()
    {

        if (isEnemy)
        {
            health = 100;
            suckable = false;
        }
        else
        {
            health = 0;
            suckable = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage)
    {

        health -= damage;

        if (health <= 0)
        {
            isDead = true;
            suckable = true;
        }

    }



}
