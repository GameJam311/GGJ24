using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class open_CloseLightEnemy : MonoBehaviour
{
    public GameObject spotlightObject; // Isik objesi
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
        // GameObjectin aktifligini tersine cevir
        spotlightObject.SetActive(!spotlightObject.activeSelf);
    }
}
