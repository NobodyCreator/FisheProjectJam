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

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
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
        Debug.Log("Horizontal Input: " + x);
        Debug.Log("Vertical Input: " + y);


        Vector3 moveDir = new Vector3(x, 0, y);
        rb.velocity = moveDir * speed;

        //flipping based on the position we are moving
        if (x!= 0 && x < 0)
        {
            sr.flipX = true;
        }
        else if (x!= 0 && x > 0)
        {
            sr.flipX = false;
        }
    }
}
