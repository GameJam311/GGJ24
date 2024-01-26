using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Watchh2 : MonoBehaviour
{
    public GameObject spotlightObject; // Işığın bağlı olduğu GameObject'i bu alandan atayın
    private float activeTime = 4f;
    private float inactiveTime = 2f;
    private bool lightActive = true;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (lightActive && timer >= activeTime)
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
    }

    void ToggleGameObject()
    {
        // GameObject'in etkinlik durumunu tersine çevirin
        spotlightObject.SetActive(!spotlightObject.activeSelf);
    }
}
