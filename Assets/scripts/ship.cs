using Assets.scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ship : MonoBehaviour
{
    int health = 100;
    int shield = 200;
    int energyRegen = 50;
    int maxEnergy = 200;
    int engineThrusterPower = 10;
    int engineTurnPower = 10;
    int engineConsumtion = 5;

    public float energy = 100;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public Camera mainCamera;

    public MonoBehaviour driverMonoBehaviour;
    public Idriver driver;

    public MonoBehaviour engineMonoBehaviour;
    public Iengine engine;

    public MonoBehaviour shipBodyMonoBehaviour;
    public IshipBody shipBody;

    public MonoBehaviour[] gunMonobehaviour;
    public Igun[] guns = Array.Empty<Igun>();

    public Rigidbody2D shipRigidBody;

    private void Start()
    {
        shipRigidBody = GetComponent<Rigidbody2D>();
        driver = driverMonoBehaviour.GetComponent<Idriver>();
        shipBody = shipBodyMonoBehaviour.GetComponent<IshipBody>();
        health = shipBody.getMaxHealth();

            var tmpGuns = new List<Igun>();
        List<string> shootActivators = new List<string>();
        for(var i = 0; i< gunMonobehaviour.Length;i++)
        {
            tmpGuns.Add(gunMonobehaviour[i].GetComponent<Igun>());
            shootActivators.Add(tmpGuns[i].triggerButton);
        }
        guns = tmpGuns.ToArray();
        engine = engineMonoBehaviour.GetComponent<Iengine>();
        engineThrusterPower = engine.getTrusterPower();
        engineTurnPower = engine.getTurnSpeed();
        engineConsumtion = engine.getPowerConsuption();


        driver.initShootListeners(shootActivators.ToArray());
        var activators = driver.getShootTriggers();
        activators[0].AddListener(Shoot);

    }

    private void Update()
    {
        if(driver != null)
        {
            move(driver.movement());
            turnShip(driver.turnTarget());
            driver.isShooting();
        }

        energy += energyRegen * Time.deltaTime;
        if(energy > maxEnergy)
        {
            energy = maxEnergy;
        }
        driver.getDash(this);
    }

    private void turnShip(Vector3 target)
    {
        target.z -= mainCamera.transform.position.z;

        target = mainCamera.ScreenToWorldPoint(target);
        Vector3 vectorToTarget = target - transform.position;

        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90f;
        if (angle < 0)
        {
            angle += 360f;
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void move( Vector2 movement)
    {
        shipRigidBody.velocity = movement * engineThrusterPower;

        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);
        viewportPos.x = Mathf.Clamp(viewportPos.x, 0.03f, 0.97f);
        viewportPos.y = Mathf.Clamp(viewportPos.y, 0.05f, 0.95f);
        transform.position = mainCamera.ViewportToWorldPoint(viewportPos);
    }

    public void changePower(float changeAmount)
    {
        energy += changeAmount;
    }

    private void Shoot()
    {
    }

    public int getHealth()
    {
        return health;
    }
    public int getShield()
    {
        return shield;
    }

    public int getmaxEnergy()
    {
        return maxEnergy;
    }

    public float getEnergy()
    {
        return energy;
    }
}
