using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LaughBar : MonoBehaviour
{
    public float laughLevel = 0;//kullanacaginiz degisken

    public GameObject valueBar;//takip eden bar

    float valueBarValue;//takip eden bar scale y degeri
    void Update()
    {
        LaughBarControl();
    }
    void LaughBarControl()
    {
        //takip eden bar scale y degerine eris
        valueBarValue = valueBar.transform.localScale.y;

        //bu objenin scale y degeri laughLevel degerine esit olsun
        this.gameObject.transform.localScale = new Vector3(1, laughLevel / 100, 1);

        //eger laugh level degismisse
        if (valueBarValue != laughLevel)
        {
            //takip eden bar smooth sekilde yeni degerini alsin
            valueBar.transform.DOScaleY(laughLevel / 100, 1f);
        }
    }
}
