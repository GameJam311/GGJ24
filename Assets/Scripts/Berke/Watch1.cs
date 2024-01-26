using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watch1 : MonoBehaviour
{

    public float speed = 5f; // Objenin hareket h�z�

    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(startPos.x + 20f, startPos.y, startPos.z);
    }

    void Update()
    {
        float Movement = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPos, Movement);

        if (transform.position == endPos)
        {
            // E�er hedefe ula��ld�ysa hedefi de�i�tir
            Vector3 temp = endPos;
            endPos = startPos;
            startPos = temp;
        }
    }
}