using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Half_Rotate_Enemy : MonoBehaviour
{
    private Quaternion startRotation;

    private void Start()
    {
        startRotation = transform.rotation;

        Rotate();
    }
    private void Rotate()
    {
        transform.DORotate(new Vector3(0f, 0f, 75f), 2f).SetEase(Ease.Linear).OnComplete(() => Back());
    }

    private void Back()
    {
        transform.DORotate(startRotation.eulerAngles, 2f).SetEase(Ease.Linear).OnComplete(() => Rotate());
    }
}
