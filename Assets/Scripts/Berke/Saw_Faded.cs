using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Saw_Faded : MonoBehaviour
{
    public SpriteRenderer sr;
    bool isFaded=false;
    float time = 0f;

    private void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    public void Fading(float fadingAmount, float fadingTime)
    {
        sr.DOFade(fadingAmount, fadingTime);
    }
    private void FixedUpdate()
    {
        if (isFaded) {
            Fading(0, 3);
            time += Time.deltaTime;

            if (time >=3f) this.gameObject.SetActive(false);

        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Light"))
        {
            isFaded = true;
        }

    }
    
}
