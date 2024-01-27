using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TimerDoor : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speedUp = 0f;
    public float speedDown = 0f;

    void Start()
    {
        MoveUpDown();
    }
    void MoveUpDown()
    {
        //objeyi baslangic yerine yerlestir
        transform.position = startPoint.position;

        //hareketi tanimla
        Sequence sequence = DOTween.Sequence();

        //asagi hizlica in
        sequence.Append(transform.DOMove(endPoint.position, speedDown).SetEase(Ease.InQuad));

        //yukari yavasca cik
        sequence.Append(transform.DOMove(startPoint.position, speedUp).SetEase(Ease.OutQuad));

        //sonsuz donguye al
        sequence.SetLoops(-1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("kapi ile carpisma oldu");
    }
}
