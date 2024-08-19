using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class npcController : MonoBehaviour
{

    public bool isEnemy, suckable, isDead;

    public float moveRange, speed, waitTime;

    bool moving;

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
        if(!isDead && !moving && waitTime <= 0)
        {

            //float step = speed * Time.deltaTime;

            Random.InitState(System.DateTime.Now.Millisecond);

            if (isEnemy)
            {



            }
            else
            {
                moving = true;

                float movementX = Random.Range(-moveRange, moveRange);
                float movementZ = Random.Range(-moveRange, moveRange);

                Vector3 newPos = new Vector3((this.transform.position.x + movementX), (this.transform.position.y), (this.transform.position.z + movementZ));

                StartCoroutine(move(newPos));

            }

            waitTime = Random.Range(0.01f, 1f);

        }
        else if(!isDead && !moving)
        {

            waitTime -= 0.1f;

        }

    }

    IEnumerator move(Vector3 newPos)
    {
        for (float i = 0.1f; i <= 1; i += 0.1f)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, newPos, i);

            yield return new WaitForSeconds(speed);

        }

        moving = false;
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
