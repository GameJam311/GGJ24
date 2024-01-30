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
    Tween tween;
    public float horizontalRepelStrength, verticalRepelStrength = 20f;

    void Start()
    {

        rb = player.GetComponent<Rigidbody2D>();
        if (this.tag == "RotateTrap")
        {
            this.transform.DORotate(new Vector3(0, 0, 360), 1).SetLoops(-1).SetEase(Ease.Linear);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D playerRigidbody = collision.GetComponent<Rigidbody2D>();

            Vector2 repelForce;

            if (PlayerMovement.isFacingRight)
            {
                // Oyuncu saða bakýyorsa, sola ve yukarýya kuvvet uygula
                repelForce = new Vector2(-horizontalRepelStrength, verticalRepelStrength);
            }
            else
            {
                // Oyuncu sola bakýyorsa, saða ve yukarýya kuvvet uygula
                repelForce = new Vector2(horizontalRepelStrength, verticalRepelStrength);
            }
            playerRigidbody.AddForce(repelForce, ForceMode2D.Impulse);

            canyok.Raise();

        }
    }
}
