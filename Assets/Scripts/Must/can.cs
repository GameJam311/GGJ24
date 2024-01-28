using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    int cancount = 0;
    public GameEvent gameEvent;
    public Transform kamera;

    public void cangg()
    {
        if(cancount >= 2)
        {
            objects[cancount].gameObject.SetActive(false);
            gameEvent.Raise();
        }
        else
        {
            objects[cancount].gameObject.SetActive(false);
            cancount++;
            kamera.DOShakePosition(0.2f, 3.5f, 5, 90).SetEase(Ease.InOutBounce);
        } 
    }
}
