using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class PushTraps : MonoBehaviour
{
    public GameObject player;
    public GameEvent canyok;
    Rigidbody2D rb;
    public float jumppower;
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        if(this.tag == "RotateTrap")
        {
            this.transform.DORotate(new Vector3(0, 0, 360), 1).SetLoops(-1).SetEase(Ease.Linear);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Transform playerTransform = collision.transform;
            if (!PlayerMovement.isFacingRight)
            {
                playerTransform.DOMoveX(playerTransform.position.x + playerTransform.position.x / 2 * 0.4f, 0.5f); //saga teptir
            }
            else
            {
                playerTransform.DOMoveX(playerTransform.position.x - playerTransform.position.x / 2 * 0.4f, 0.5f);//sola teptir
            }
            
            canyok.Raise();
        }
    }
}
