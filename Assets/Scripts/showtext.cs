using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showtext : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D called with: " + collision.collider.name);
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("OnCollisionExit2D called with: " + collision.collider.name);
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
