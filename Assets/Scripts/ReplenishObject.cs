using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplenishObject: MonoBehaviour
{
    public bool IsUsed = false;//check if object has been SUCC'd

    public void Use()
    {
        IsUsed = true;
    }
}
