using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Recoil : MonoBehaviour
{
    private Vector3 enemyDirection;
    public float goBackTime = 1f;
    public float goBackSpeed = 35f;
    private float goBackStartTime = 0f;
    bool isBullet, isShotgunBullet = false;
    private bool goBackActive = false;

    PlayerMovement player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RotateTrap"))
        {
            print("player degdi");
            goBackActive = true;
            goBackStartTime = Time.time;
            enemyDirection = -collision.transform.right;

            lowGoBack();
        }
    }
            
    public void lowGoBack()
    {
        if (goBackActive)
        {
            if (Time.time < goBackStartTime + goBackTime)
            {
                if (PlayerMovement.isFacingRight)
                {
                    print("sola tepti");
                    // Sola tepme islemi
                    Vector3 newPos = transform.position + enemyDirection * goBackSpeed * Time.deltaTime;
                    transform.position = newPos;
                }
                else if (!PlayerMovement.isFacingRight)
                {
                    print("saga tepti");
                    // Sola tepme islemi
                    Vector3 newPos = transform.position - enemyDirection * goBackSpeed * Time.deltaTime;
                    transform.position = newPos;
                }
            }
            //else
            //{
            //    // Yurume islemi
            //    Vector3 newPos = transform.position + enemyDirection * player.speed * Time.deltaTime;
            //    transform.position = newPos;
            //    goBackActive = false;
            //}
        }
    }
}
