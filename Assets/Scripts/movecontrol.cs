using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecontrol : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float towards = Input.GetAxis("Vertical");
        if (Input.GetAxis("Vertical") != 0)
        {
            UpdateAnim();
        }
        else if (Input.GetAxis("Vertical") == 0)
        {
            UpdateAnim2();
        }
    }

    void UpdateAnim()
    {
        animator.SetBool("isMoving",true);
    }

    void UpdateAnim2()
    {
        animator.SetBool("isMoving", false);
    }
}
