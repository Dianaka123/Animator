using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private Animator _animator;

    private int Trigger = Animator.StringToHash( "New Trigger");
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Animator>() == null)
        {
            return;
        }

        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger(Trigger );
           
        }
    }
}
