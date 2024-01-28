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
            float originalX = playerTransform.position.x;

            if (!PlayerMovement.isFacingRight)
            {
                playerTransform.DOMoveX(originalX + originalX / 2 * 0.4f, 0.5f); // Saða tepme
            }
            else
            {
                playerTransform.DOMoveX(originalX - originalX / 2 * 0.4f, 0.5f); // Sola tepme
            }

            canyok.Raise();

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Transform playerTransform = collision.transform;
        }
    }
}
