﻿using UnityEngine;

public class CoinCollisionController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter");
            Destroy(gameObject);
        }
    }
}
