using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceGlass : MonoBehaviour
{

    [SerializeField] private string[] glassFruits = new string[3]; 
    
    void Start()
    {
        
    }

    
    void Update()
    {
        fillGlassFruitsArray();

        
    }


    private void fillGlassFruitsArray()
    {
        glassFruits = GameObject.FindWithTag("CodeBlender").GetComponent<smoothieMaker>().fruitsToArray;

    }
}
