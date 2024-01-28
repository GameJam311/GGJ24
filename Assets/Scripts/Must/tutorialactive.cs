using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialactive : MonoBehaviour
{
    public GameEvent durla;
    public Transform text;
    private void OnEnable()
    {
        text.DOScale(1.25f,1).SetLoops(-1, LoopType.Yoyo);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            durla.Raise();
            text.gameObject.SetActive(false);
            this.gameObject.SetActive(false);  
        }
    }
}
