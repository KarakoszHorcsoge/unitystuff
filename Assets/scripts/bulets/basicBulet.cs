using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulet : MonoBehaviour, Ibullet
{
    public void setDestroyTimer(float time)
    {
        Destroy(gameObject,time);
    }
}
