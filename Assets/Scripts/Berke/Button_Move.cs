using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Button_Move : MonoBehaviour
{
    private Vector3 baslangicPozisyonu;
    private bool hareketEdiyor = false;

    private void Start()
    {
        baslangicPozisyonu = transform.position;
    }


    private void HareketEt()
    {
        hareketEdiyor = true;

        transform.DOMoveY(baslangicPozisyonu.y - 1f, 1f).SetEase(Ease.OutQuad);
    }

    private void GeriDon()
    {
        hareketEdiyor = false;

        transform.DOMoveY(baslangicPozisyonu.y, 1f).SetEase(Ease.InQuad);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hareketEdiyor && other.gameObject.CompareTag("Player"))
        {
            print("PLAYER BUTONA DEGDÝ");
            HareketEt();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (hareketEdiyor && other.gameObject.CompareTag("Player"))
        {
            GeriDon();
        }
    }
}
