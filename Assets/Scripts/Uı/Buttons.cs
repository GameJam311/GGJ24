using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Buttons : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject panel;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(panelcontrol());
    }
    public void ButtonSound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound, 1f);
    }
    public void ButtonEffectEnter(GameObject button)
    {
        button.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.1f);
    }
    public void ButtonEffectExit(GameObject button)
    {
        button.transform.DOScale(new Vector3(1f, 1f, 1f), 0.1f);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    IEnumerator panelcontrol()
    {
        yield return new WaitForSeconds(1);
        panel.SetActive(false);
    }
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
