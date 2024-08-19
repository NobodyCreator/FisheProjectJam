using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiController : MonoBehaviour
{

    public GameObject ePrompt;

    float range;

    bool display;

    Collider[] hitColliders;

    // Start is called before the first frame update
    void Start()
    {

        ePrompt.SetActive(false);
        range = gameObject.GetComponent<PlayerController>().replenishRange;

    }

    // Update is called once per frame
    void Update()
    {

        display = false;

        hitColliders = Physics.OverlapSphere(transform.position, range);

        foreach (var collide in hitColliders) {
            if ((collide.CompareTag("ReplenishObject") && collide.GetComponent<ReplenishObject>().IsUsed == false) || collide.CompareTag("EnemyObject") && collide.GetComponent<npcController>().suckable == true) {

                display = true;
            
            }
        }

        ePrompt.SetActive(display);

    }

}
