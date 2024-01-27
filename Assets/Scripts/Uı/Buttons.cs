using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void ButtonSound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound, 1f);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
