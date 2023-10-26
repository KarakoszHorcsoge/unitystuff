using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class targetDummy : MonoBehaviour, Idriver
{
    public dashDirection getDash(ship parentShip)
    {
        throw new System.NotImplementedException();
    }

    public List<UnityEvent> getShootTriggers()
    {
        return new List<UnityEvent>();
    }

    public void initShootListeners(string[] shootActivators)
    {
        return;
    }

    public void isShooting()
    {
        return;
    }

    public Vector2 movement()
    {
        return Vector2.zero;
    }

    public Vector3 turnTarget()
    {
        return Vector3.zero;
    }
}
