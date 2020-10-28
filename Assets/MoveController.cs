using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoveController : MonoBehaviour
{
    private Animator animator;
    private int moveTrigger = Animator.StringToHash("Move");
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool(moveTrigger, true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool(moveTrigger, false);
        }
    }
}
