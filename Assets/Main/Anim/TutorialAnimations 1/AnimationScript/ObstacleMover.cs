using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    bool animBool;
    Animator animator;
    float flipCounter;
    public float lengthOfAnimation = 3;

	void Start ()
    {
        animator = this.GetComponent<Animator>();
        animBool = animator.GetBool("isUp");
        InvokeRepeating("Flipper",lengthOfAnimation,lengthOfAnimation);
    }
	
    void Flipper()
    {
        if (animBool == false)
        {
            animBool = true;
            animator.SetBool("isUp", true);
        }
        else if (animBool == true)
        {
            animBool = false;
            animator.SetBool("isUp", false);
        }
    }
}
