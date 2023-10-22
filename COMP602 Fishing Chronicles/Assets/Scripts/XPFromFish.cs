using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPFromFish : MonoBehaviour
{
    public float xpAmount = 1.0f;


    public void giveXP()
    {
       StandardVars.vars.getXP(xpAmount);
    }
}
