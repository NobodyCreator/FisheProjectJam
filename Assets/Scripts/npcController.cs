using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class npcController : MonoBehaviour
{

    public bool isEnemy, suckable, isDead;

    public float moveRange, speed, waitTime;

    bool moving, possible;

    int health;

    // Start is called before the first frame update
    void Start()
    {

        possible = false;

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

                //float movementX = Random.Range(-moveRange, moveRange);
                //float movementZ = Random.Range(-moveRange, moveRange);

                //Vector3 newPos = new Vector3((this.transform.position.x + movementX), (this.transform.position.y), (this.transform.position.z + movementZ));
                //Debug.Log(newPos);
                //StartCoroutine(move(newPos));

                Vector3 newPos = this.transform.position;
                RaycastHit hitInfo;

                while (possible == false)
                {

                    float movementX = Random.Range(-moveRange, moveRange);
                    float movementZ = Random.Range(-moveRange, moveRange);

                    newPos = new Vector3((this.transform.position.x + movementX), (this.transform.position.y), (this.transform.position.z + movementZ));
                    Debug.Log(newPos);

                    if (Physics.BoxCast(this.transform.position, new Vector3(0.1f, 0.1f, 0.1f), (this.transform.position - newPos).normalized, out hitInfo, Quaternion.identity, Vector3.Distance(newPos, this.transform.position)))
                    {
                        Debug.Log("hit");
                    }
                    else
                    {
                        Debug.Log(newPos);
                        possible = true;
                    }
                }

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
