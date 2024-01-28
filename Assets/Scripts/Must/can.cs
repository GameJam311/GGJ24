using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class can : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    int cancount = 0;
    public GameEvent gameEvent;
    public GameEvent durla;
    public Transform kamera;
    public GameObject tutorialpanel;
    private void OnEnable()
    {
        int trans = PlayerPrefs.GetInt("trans");
        if (trans == 1)
        {
            StartCoroutine(tutorial());
        }
        PlayerPrefs.SetInt("trans", 0);
    }
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
    
    IEnumerator tutorial()
    {
        yield return new WaitForSeconds(1);
        tutorialpanel.SetActive(true);
        durla.Raise();
    }
}
