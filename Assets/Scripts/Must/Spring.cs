using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public AudioClip land;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<AudioSource>().PlayOneShot(land, 1f);
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector3(0,3250,0));
        }
    }
}
