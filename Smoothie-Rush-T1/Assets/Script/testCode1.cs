using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCode1 : MonoBehaviour
{
    public Animator testAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void testTrigger()
    {
        testAnimator.SetTrigger("testTrigger");
    }
}
