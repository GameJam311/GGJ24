using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showtext : MonoBehaviour
{
    public GameObject proxxxtext;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            proxxxtext.SetActive(true);
            proxxxtext.transform.DOScale(1.5f, 1).SetLoops(-1, LoopType.Yoyo);
            Time.timeScale = 0;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            proxxxtext.SetActive(false);
            Time.timeScale = 1;
            this.gameObject.SetActive(false);
        }
    }
}
