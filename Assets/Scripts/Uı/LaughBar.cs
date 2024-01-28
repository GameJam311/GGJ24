using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LaughBar : MonoBehaviour
{
    public static float laughLevel = 0;//kullanacaginiz degisken
    public GameEvent gameEvent;

    float value;//takip eden bar scale y degeri
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        LaughBorder();
        LaughBarControl();
        LaughSounds();
    }
    void LaughSounds()
    {       
        if (laughLevel < 25)
        {
            audioSource.pitch = 1f; 
        }
        else if (laughLevel < 50)
        {
            audioSource.pitch = 0.8f;
        }
        else if (laughLevel < 75)
        {
            audioSource.pitch = 0.6f;
        }
        else if (laughLevel < 100)
        {
            audioSource.pitch = 0.4f;
        }
    }
    void LaughBarControl()
    {
        //takip eden bar scale y degerine eris
        value = transform.localScale.y;

        //bu objenin scale y degeri laughLevel degerine esit olsun
        this.gameObject.transform.localScale = new Vector3(1, laughLevel / 100, 1);

        //eger laugh level degismisse
        if (value != laughLevel)
        {
            //takip eden bar smooth sekilde yeni degerini alsin
            transform.DOScaleY(laughLevel / 100, 1f);
        }
    }
    void LaughBorder()
    {
        //100 den buyuk olmasini engelle
        if (laughLevel >= 100f)
        {
            laughLevel = 100f;
            gameEvent.Raise();
        }
        //0 dan kucuk olmasini engelle
        else if(laughLevel <= 0)
        {
            laughLevel = 0f;
        }
    }
}
