using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{


    public string fruitType;

    public void hideFruit()
    {
        this.gameObject.SetActive(false);
    }

    
}
