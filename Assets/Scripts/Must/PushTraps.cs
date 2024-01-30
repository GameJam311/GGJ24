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


    private Vector3 playerDirection;
    public float goBackTime = 0.01f;
    public float goBackSpeed = 1500f;
    private float goBackStartTime = 0f;
    private bool goBackActive = false;

    void Start()
    {
        playerDirection = Vector3.right;

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
            //goBackActive = true;
            //goBackStartTime = Time.time;
            //playerDirection = -collision.transform.right;

            //lowGoBack();
            Transform playerTransform = collision.transform;
            float originalX = playerTransform.position.x;

            if (tween != null)
                tween?.Kill();
            tween.Play();

            if (!PlayerMovement.isFacingRight)
            {
                playerTransform.DOMoveX(originalX - originalX / 2 * 0.2f, 0.1f); // Sola tepme
                tween = playerTransform.DOMoveX(originalX + originalX / 2 * 0.1f, 0.1f);
            }
            else if(PlayerMovement.isFacingRight)
            {
                playerTransform.DOMoveX(originalX - originalX / 2 * 0.2f, 0.1f); // Sola tepme
                tween = playerTransform.DOMoveX(originalX - originalX / 2 * 0.1f, 0.1f); // Sola tepme
            }
            

            canyok.Raise();

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            goBackActive = false;
            Transform playerTransform = collision.transform;
        }
    }
    //public void lowGoBack()
    //{
    //    if (goBackActive)
    //    {
    //        if (Time.time < goBackStartTime + goBackTime)
    //        {
    //            if (PlayerMovement.isFacingRight)
    //            {
    //                print("sola tepti");
    //                // Sola tepme islemi
    //                Vector3 newPos = player.transform.position + playerDirection * goBackSpeed * Time.deltaTime;
    //                player.transform.position += newPos;
    //            }
    //            else if (!PlayerMovement.isFacingRight)
    //            {
    //                print("saga tepti");
    //                // Sola tepme islemi
    //                Vector3 newPos = player.transform.position - playerDirection * goBackSpeed * Time.deltaTime;
    //                player.transform.position= newPos;
    //            }
    //        }
    //    }
    //}
}
