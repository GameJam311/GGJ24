using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Intro : MonoBehaviour
{
    public AudioClip buttonDown, buttonUp;
    AudioSource audioSource;

    public GameObject lampSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();      
        StartCoroutine(StartIntro());
    }
    void ChangeColor(string hexColor)
    {
        Color newColor;
        if (ColorUtility.TryParseHtmlString(hexColor, out newColor))
        {
            this.gameObject.GetComponent<Image>().color = newColor;
        }
    }
    IEnumerator StartIntro()
    {
        yield return new WaitForSeconds(2f);

        ChangeColor("#FFFFFF");
        audioSource.PlayOneShot(buttonDown, 1f);

        yield return new WaitForSeconds(3f);

        ChangeColor("#000000");
        audioSource.PlayOneShot(buttonUp, 1f);
        lampSound.SetActive(false);

        yield return new WaitForSeconds(1f);

        Destroy(this.gameObject);
    }
}
