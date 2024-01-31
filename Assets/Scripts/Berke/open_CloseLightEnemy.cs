using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class open_CloseLightEnemy : MonoBehaviour
{
    public GameObject spotlightObject; // Isik objesi
    public float activeTime = 4f;
    public float inactiveTime = 2f;
    private bool lightActive = true;
    private float timer = 0f;
    public float bonusTimer;

    void Update()
    {
        timer += Time.deltaTime;

        if (lightActive && timer + bonusTimer >= activeTime)
        {
            ToggleGameObject();
            lightActive = false;
            timer = 0f;
        }
        else if (!lightActive && timer >= inactiveTime)
        {
            ToggleGameObject();
            lightActive = true;
            timer = 0f;
        }
        bonusTimer = 0f;
    }

    void ToggleGameObject()
    {
        // GameObjectin aktifligini tersine cevir
        spotlightObject.SetActive(!spotlightObject.activeSelf);
    }
}
