using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public UnityEvent whenPickUp;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            whenPickUp?.Invoke();
            Destroy(gameObject);
        }
    }
}
