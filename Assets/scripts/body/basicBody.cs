using Assets.scripts;
using UnityEngine;

public class basicBody : MonoBehaviour, IshipBody
{

    public Transform[] gunPosition;
    public int maxHealth;
    public int weight;

    public int getGunCount()
    {
        return gunPosition.Length;
    }

    public Transform getGunPosition(int pos)
    {
        return gunPosition[pos];
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public int getWeight()
    {
        return weight;
    }
}