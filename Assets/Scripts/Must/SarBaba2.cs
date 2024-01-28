using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SarBaba2 : MonoBehaviour
{
    public List<GameObject> spriteList = new List<GameObject>();
    public TextMeshProUGUI textMeshPro;
    int framecount = 0;

    public AudioClip land;
    AudioSource audioSource;
    private void Start()
    {
        textMeshPro.gameObject.transform.DOScale(1.5f, 1).SetLoops(-1, LoopType.Yoyo);
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(land, 1f);
            sarrbaba();
            if (framecount < 5)
            {
                framecount++;
            }
        }
    }
    void sarrbaba()
    {
        switch (framecount)
        {
            case 0:
                Vector2 num0 = new Vector2(0.84f, 3.33f);
                spriteList[0].gameObject.transform.DOMove(num0, 1).SetEase(Ease.OutQuart);
                break;
            case 1:
                Vector2 num1 = new Vector2(6.75f, 2.71f);
                spriteList[1].gameObject.transform.DOMove(num1, 1).SetEase(Ease.OutQuart);
                break;
            case 2:
                Vector2 num2 = new Vector2(-6.2f, -2.73f);
                spriteList[2].gameObject.transform.DOMove(num2, 1).SetEase(Ease.OutQuart);
                break;
            case 3:
                Vector2 num3 = new Vector2(3.03f, -2.54f);
                spriteList[3].gameObject.transform.DOMove(num3, 1).SetEase(Ease.OutQuart);
                textMeshPro.text = "Press 'Space' for next scene";
                break;
            case 4:
                SceneChanger.instance.NextLvl();
                break;
        }
    }
}