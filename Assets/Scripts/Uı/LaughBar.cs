using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LaughBar : MonoBehaviour
{
    public static float laughLevel = 0;//kullanacaginiz degisken

    public GameObject valueBar;//takip eden bar

    float valueBarValue;//takip eden bar scale y degeri
    void Update()
    {
        LaughBorder();
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
    void LaughBorder()
    {
        //100 den buyuk olmasini engelle
        if (laughLevel >= 100f)
        {
            laughLevel = 100f;
        }
        //0 dan kucuk olmasini engelle
        else if(laughLevel <= 0)
        {
            laughLevel = 0f;
        }
    }
}
