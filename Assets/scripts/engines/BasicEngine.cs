using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEngine : MonoBehaviour, Iengine
{
    public int getDodgeConsuption()
    {
        return 100;
    }

    public int getDodgePower()
    {
        return 30;
    }

    public int getPowerConsuption()
    {
        return 5;
    }

    public int getTrusterPower()
    {
        return 15;
    }

    public int getTurnSpeed()
    {
        return 40;
    }
}
