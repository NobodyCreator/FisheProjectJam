using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingObject : MonoBehaviour
{
    public bool IsUsed = false; //used???
    public float cooldownDuration = 20f; //not used after x secs

    public void Use()
    {
        if (!IsUsed)
        {
            IsUsed = true;
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);
        IsUsed = false; //RESET YOUR WATER YOU
    }
}
