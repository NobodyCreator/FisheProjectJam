using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public int fisheAmount = 300;
    public int currentFishe;

    public int maxElectronics = 100;
    public int currentElectronics;

    public GameObject healthBar, electronicsBar, fisheBar;

    void Start()
    {

        currentHealth = maxHealth;
        healthBar.GetComponent<Slider>().value = currentHealth;

        currentFishe = 3;
        fisheBar.GetComponent<Slider>().value = currentFishe;

        currentElectronics = 0;
        electronicsBar.GetComponent<Slider>().value = currentElectronics;

    }

    private void Update()
    {

        if (maxElectronics == currentElectronics)
        {
            //WINNAR
        }

        if (fisheAmount == currentFishe) { 
        
            //UPGRADE
            // TODO: FOR NOW MAKE THE GUY FASTER AND uhhhhhhhhhhhhhhhhhhh idk
            // PUNCH HARDA
        
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        PlayerPrefs.SetFloat("health", (float)currentHealth);
        healthBar.GetComponent<Slider>().value = currentHealth;

        if (currentHealth <= 0)
        {
            PlayerPrefs.SetFloat("health", 100f);
            Death();
        }
    }

    public void TakeElectronics(int amount)
    {
        currentElectronics = Mathf.Min(currentElectronics + amount, maxElectronics);
        electronicsBar.GetComponent<Slider>().value = currentElectronics;
    }

    public void takeHuman (int amount)
    {
        currentFishe = Mathf.Min(currentFishe + amount, fisheAmount);
        fisheBar.GetComponent <Slider>().value = currentFishe;
    }

    public void Healing(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        healthBar.GetComponent<Slider>().value = currentHealth;
    }

        void Death()
        {
            Destroy(gameObject);//kills lil bro for now
        }
}
