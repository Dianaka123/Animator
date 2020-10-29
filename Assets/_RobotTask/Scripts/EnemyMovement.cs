using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Vector2 rayDirection = new Vector2(1.5f, -0.5f);
    [SerializeField] private Vector2 enemyDirection = Vector2.right;
    [SerializeField] private float speed = 5;
    
    private bool isGoToRigth;

    private void FixedUpdate()
    {
        Vector3 offset = Time.deltaTime * speed * enemyDirection;
        transform.position += offset;
    }

    private void Update()
    {
        var hit = Physics2D.Raycast(transform.position, rayDirection , 2f, _layerMask);
        Debug.DrawRay(transform.position, rayDirection);
        if (hit.collider != null)
        {
            rayDirection.x *= -1;
            enemyDirection *= -1;
            
            var localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
            
            Debug.Log(hit.collider.name);
        }
    }
}
