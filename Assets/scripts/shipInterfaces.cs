using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.scripts
{
    public  interface Idriver
    {
        public Vector3 turnTarget();
        public Vector2 movement();
        public List<UnityEvent> getShootTriggers();
        public void initShootListeners(string[] shootActivators);
        public void isShooting();
        public dashDirection getDash(ship parentShip);
    }

    public interface Iengine
    {
        public int getTurnSpeed();
        public int getTrusterPower();
        public int getPowerConsuption();
        public int getDodgePower();
        public int getDodgeConsuption();
    }

    public interface Ibullet
    {
        public void setDestroyTimer(float timer);
    }

    public interface IshipBody
    {
        int getGunCount();
        Transform getGunPosition(int pos);
        int getMaxHealth();
        int getWeight();
    }

    public interface Igun
    {
        public int basicDmg { get; set; }
        public int actualDmg { get; set; }
        public float fireRate { get; set; }
        public float bulletSpeed { get; set; }
        public int energyConsumption { get; set; }
        public string triggerButton { get; set; }
        public GameObject bulletAsset { get; set; }
        public void shoot(ship parentShip);
    }
}
