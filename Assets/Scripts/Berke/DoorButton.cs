using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorButton : MonoBehaviour
{
    public GameObject door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 newPos = new Vector3(door.transform.position.x, door.transform.position.y + 15, door.transform.position.z);
            door.gameObject.transform.DOMove(newPos, 2f);
        }
    }
}
