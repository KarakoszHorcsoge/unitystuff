using Assets.scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour, Idriver
{
    private List<UnityEvent> Shoot = new List<UnityEvent>();
    private string[] shootActivators = new string[0];

    private float lastDashTime = 0f;

    private Vector2 dashDir;

    public void initShootListeners(string[] shootActivators)
    {
        this.shootActivators = shootActivators;
        for(int i = 0; i < this.Shoot.Count; i++)
        {
            this.Shoot[i].RemoveAllListeners();
        }
        Shoot.Clear();
        for (int i = 0; i < shootActivators.Length; i++)
        {
            this.Shoot.Add(new UnityEvent());
        }
    }

    public List<UnityEvent> getShootTriggers()
    {
        return Shoot;
    }

    public Vector2 movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        return new Vector2(horizontalInput, verticalInput);
    }

    public Vector3 turnTarget()
    {
        return Input.mousePosition;
    }

    public dashDirection getDash(ship parentShip)
    {
        var rb = parentShip.GetComponent<Rigidbody2D>();
        float angleRadians = Mathf.Atan2(parentShip.transform.up.y, parentShip.transform.up.x);
        float angleDegrees = angleRadians * Mathf.Rad2Deg;
        var res = 0;
        if (Input.GetKeyDown("q")) 
        {
            parentShip.changePower(-parentShip.engine.getDodgeConsuption());
            var force = (Quaternion.Euler(0, 0, angleDegrees) * new Vector2(0, 90) * 400);

            parentShip.StartCoroutine(dash(force, rb));
            ++res; 
        }
        if (Input.GetKeyDown("e"))
        {
            parentShip.changePower(-parentShip.engine.getDodgeConsuption());
            var force = Quaternion.Euler(0, 0, angleDegrees) * new Vector2(0, 90) * 400;
            force *= -1;
            parentShip.StartCoroutine(dash(force, rb));
            res += 2;
        }
        lastDashTime = Time.time;
        return (dashDirection)res;
    }

    private IEnumerator dash(Vector2 force, Rigidbody2D rb)
    {
        float duration = 10f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float percentComplete = elapsed / duration;

            float easeOutValue = 1 - Mathf.Pow(1 - percentComplete, 3);

            Vector2 frameForce = force * easeOutValue;

            rb.AddForce(frameForce * Time.deltaTime);

            elapsed += Time.deltaTime;
            yield return null;
        }
    }



    public void isShooting()
    {
        for(int i = 0;i<shootActivators.Length;i++)
        {
            if (Input.GetButton(shootActivators[i]))
            {
                Shoot[i].Invoke();
            }
        }
    }
}
