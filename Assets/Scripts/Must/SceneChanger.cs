using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;
    public Animator animator;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void NextLvl()
    {
        StartCoroutine(loadScene());
    }
    IEnumerator loadScene()
    {
        int sceneBuild = SceneManager.GetActiveScene().buildIndex;
        if(sceneBuild == 1 )
        {
            PlayerPrefs.SetInt("trans", 1);
        }
        animator.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        animator.SetTrigger("Start");
    }
}
