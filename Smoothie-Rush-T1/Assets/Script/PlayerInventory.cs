using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    private float money;
    public int fruits = 0; 
    // Start is called before the first frame update



    public void addFruitToInventory()
    {
        if (fruits  < 4)
        {
            fruits++;
        }
    }
}
