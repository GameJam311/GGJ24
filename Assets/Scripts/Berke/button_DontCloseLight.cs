using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_DontCloseLight : MonoBehaviour
{
    public GameObject lightObject; // Isik objesi
    public float time = 3f;
    private bool isLightDisactive = false;
    [SerializeField] Sprite sprite;

    private void Update()
    {
        //if (isLightDisactive)
        //{
        //    time -= Time.deltaTime;
        //    if (time <= 0f)
        //    {
        //        lightDisactive();
        //    }
        //}
    }
    private void lightActive()
    {
        //lightObject.SetActive(false);
        isLightDisactive = true;
        time = 3f;
    }
    //private void lightDisactive()
    //{
    //    lightObject.SetActive(true);
    //    isLightDisactive = false;
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lightActive();
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}
