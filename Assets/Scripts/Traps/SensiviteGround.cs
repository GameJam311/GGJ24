using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SensiviteGround : MonoBehaviour
{
    public AudioClip brokeSound;
    AudioSource audioSource;

    public Sprite normalSprite;
    public Sprite brokenSprite;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnDisable()
    {
        //3 saniye sonra objeyi yeniden ac
        Invoke("StartRespawn", 3f);
    }
    void ChangeSprite(Sprite sprite)
    {
        //sprite degistir
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
    void StartRespawn()
    {
        //objeyi yeniden ac
        this.gameObject.SetActive(true);
        //obje normal sprite ile respawn olsun
        ChangeSprite(normalSprite);
    }
    IEnumerator StartBreak()
    {
        //10 kere sallanti komutu cagir
        for(int i = 0 ; i < 10 ; i++)
        {
            transform.DOShakePosition(1f, 0.04f);
        }
        
        //bekle
        yield return new WaitForSeconds(1f);

        //kirik sprite gec
        ChangeSprite(brokenSprite);

        //10 kere daha siddetli sallanti komutu cagir
        for (int i = 0 ; i < 10 ; i++)
        {
            transform.DOShakePosition(1f, 0.06f);
        }

        //bekle
        yield return new WaitForSeconds(1f);

        //objeyi kapat
        this.gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //karakter platforma bastiginda kirilma baslasin
        if (collision.gameObject.tag.Equals("Player"))
        {
            StartCoroutine(StartBreak());
            //audioSource.PlayOneShot(brokeSound, 1f);
        }
    }
}
