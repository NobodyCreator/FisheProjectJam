using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiController : MonoBehaviour
{
    public GameObject electronicsSlider, fisheSlider, healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damageTaken)
    {

        healthSlider.GetComponent<Slider>().value -= damageTaken;

    }

    public void gainElectronics(int electronicsGained)
    {

        electronicsSlider.GetComponent<Slider>().value += electronicsGained;

    }

    public void gainPeople(int peopleGained) { 
        
        fisheSlider.GetComponent<Slider>().value += peopleGained;
        
    }
}
