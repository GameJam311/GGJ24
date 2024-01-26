using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SensiviteGround : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite brokenSprite;
    private void OnEnable()
    {
        ChangeSprite(normalSprite);
    }
    private void OnDisable()
    {
        StartCoroutine(RespawnObject());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(StartBreak());
        }
    }
    void ChangeSprite(Sprite sprite)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
    IEnumerator StartBreak()
    {
        for(int i = 0 ; i < 10 ; i++)
        {
            transform.DOShakePosition(1f, 0.05f);
        }
       
        yield return new WaitForSeconds(1f);

        ChangeSprite(brokenSprite);

        for (int i = 0 ; i < 10 ; i++)
        {
            transform.DOShakePosition(2f, 0.08f);
        }

        yield return new WaitForSeconds(2f);

        this.gameObject.SetActive(false);
    }
    IEnumerator RespawnObject()
    {
        yield return new WaitForSeconds(3f);

        this.gameObject.SetActive(true);
    }
}
