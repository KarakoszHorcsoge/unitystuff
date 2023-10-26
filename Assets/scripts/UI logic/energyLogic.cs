using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyLogic : MonoBehaviour
{
    //public float maxEnergy = 100f;
    //public float currentEnergy = 50f; // example starting value
    public MonoBehaviour playerMonobehavior;
    private ship player;
    private Image energyCircle;
    private int maxEnergy;
    private float currentEnergy;

    private void Start()
    {
        energyCircle = GetComponent<Image>();
        energyCircle.type = Image.Type.Filled;
        energyCircle.fillMethod = Image.FillMethod.Radial360;
        UpdateEnergyIndicator();
        player = playerMonobehavior.GetComponent<ship>();
        maxEnergy = player.getmaxEnergy();
    }

    private void Update()
    {
        currentEnergy = player.getEnergy();
        UpdateEnergyIndicator();

        Vector2 mousePosition = Input.mousePosition;
        transform.position = mousePosition;
    }

    private void UpdateEnergyIndicator()
    {
        float fillAmount = currentEnergy / maxEnergy;
        energyCircle.fillAmount = fillAmount;
    }
}
