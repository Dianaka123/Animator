using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RobotBoyController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
   
    private int _run = Animator.StringToHash("IsRun");
    private int _crunching = Animator.StringToHash("IsCrouch");
    private int _jump = Animator.StringToHash("JumpTrigger");

    private bool _isRun;
    private bool _isCrunching;
    
    private void Reset()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _isRun = true;
            _animator.SetBool(_run,_isRun);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _isRun = false;
            _animator.SetBool(_run, _isRun);
        }

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            _isCrunching = true;
            _animator.SetBool(_crunching, _isCrunching);
        }
        
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
        {
            _isCrunching = false;
            _animator.SetBool(_crunching, _isCrunching);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger(_jump);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _animator.ResetTrigger(_jump);
        }
    }
}
