using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldLogic : MonoBehaviour
{
    public MonoBehaviour playerMonobehavior;
    private ship player;
    private RectTransform rectTransform;

    void Start()
    {
        player = playerMonobehavior.GetComponent<ship>();
        rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(player.getShield(), rectTransform.sizeDelta.y);
    }
}
