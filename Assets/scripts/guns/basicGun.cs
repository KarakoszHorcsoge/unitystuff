using Assets.scripts;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class basicGun : MonoBehaviour, Igun
{
    public int basicDmg { get; set; } = 50;
    public int actualDmg { get; set; } = 50;
    public float fireRate { get; set; } = 4;
    public int energyConsumption { get; set; } = 10;
    public string triggerButton { get; set; } = "fire1";
    public GameObject bulletAsset { get; set; } = null;
    public float bulletSpeed { get; set; } = 100;

    private float lastShotTime = 0;

    public void shoot(ship parentShip)
    {
        if (parentShip.energy > 10 && Time.time > lastShotTime + 0.1)
        {
            GameObject bullet = Instantiate(bulletAsset, parentShip.shipBody.getGunPosition(0).transform.position, parentShip.transform.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = bullet.transform.up * bulletSpeed;
            var buletInterface = bullet.GetComponent<Ibullet>();
            buletInterface.setDestroyTimer(1.5F);

            parentShip.energy -= 30;

            lastShotTime = Time.time;
        }
    }
}