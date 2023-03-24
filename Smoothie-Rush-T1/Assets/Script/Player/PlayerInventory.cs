using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    private float money;
    public int fruits = 0;
    public List<string> inventoryFruits; 

    private GameObject fridge;

    private void Start()
    {
    }

    public void addFruitToInventory()
    {
        if (fruits  < 4)
        {
          fruits++;
        }
    }

    public void addFruitToBlender()
    {
        if (fruits >= 4)
        {
            fruits--;
        }
    }




}
