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
            this.transform.DORotate(new Vector3(0, 0, 180), 1, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector2 pushDirection = (player.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(pushDirection.x * jumppower, pushDirection.y * jumppower);
            canyok.Raise();
        }
    }
}
