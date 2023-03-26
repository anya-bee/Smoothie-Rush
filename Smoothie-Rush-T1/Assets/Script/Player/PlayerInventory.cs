using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    private float money;
    public int playerFruits = 0;
    public List<GameObject> inventoryFruits; 

    private GameObject fridge;

    private void Start()
    {
    }

    public void addFruitToInventory()
    {
        if (playerFruits  < 4)
        {
          playerFruits++;
        }
    }

    public void addFruitToBlender()
    {
        if (playerFruits >= 4)
        {
            playerFruits--;
        }
    }

}
