using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TrapController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private readonly int _trapTrigger = Animator.StringToHash("Trap");
    private void Reset()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetTrigger(_trapTrigger);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _animator.ResetTrigger(_trapTrigger);
    }
}
