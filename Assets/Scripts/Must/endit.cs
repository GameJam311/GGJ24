using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endit : MonoBehaviour
{
    public GameObject transition;
    private void Start()
    {
        Invoke("buu", 1f);
    }
    void buu()
    {
        transition.SetActive(false);
    }
}
