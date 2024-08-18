using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public int fisheAmount = 300;
    public int currentFishe;

    public int maxElectronics = 100;
    public int currentElectronics;

    void Start()
    {
        currentHealth = maxHealth;
        currentFishe = 3;
        currentElectronics = 0;
}

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void TakeElectronics(int amount)
    {
        currentElectronics = Mathf.Min(currentElectronics + amount, maxElectronics);
    }

        void Death()
        {
            Destroy(gameObject);//kills lil bro for now
        }
}
