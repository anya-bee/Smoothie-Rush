using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothieJuice : MonoBehaviour
{

    public Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("juiceReady", false);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startSmoothieJuice()
    {
        this.gameObject.SetActive(true); 
    }

}
