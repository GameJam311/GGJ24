using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SarBaba : MonoBehaviour
{
    public List<Sprite> spriteList = new List<Sprite>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("sd");
        }
    }
}
