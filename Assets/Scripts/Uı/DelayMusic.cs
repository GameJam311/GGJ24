using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayMusic : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayDelayed(6f);
    }
}
