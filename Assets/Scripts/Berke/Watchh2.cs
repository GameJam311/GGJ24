using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Watchh2 : MonoBehaviour
{
    public GameObject spotlightObject; // Işığın bağlı olduğu GameObject'i bu alandan atayın

    private float waitTime = 4f;
    private float Timee = 0f;
    private bool lightActive = true;

    void Update()
    {
        Timee += Time.deltaTime;

        if (Timee >= waitTime)
        {
            if (lightActive)
            {
                print("isik kapali");
                ToggleGameObject();
                lightActive = false;
                Timee = 0f;
            }
            else
            {
                print("isik acik");
                ToggleGameObject();
                lightActive = true;
                Timee = 0f;
            }
        }
    }

    void ToggleGameObject()
    {
        // GameObject'in etkinlik durumunu tersine çevirin
        spotlightObject.SetActive(!spotlightObject.activeSelf);
    }
}
