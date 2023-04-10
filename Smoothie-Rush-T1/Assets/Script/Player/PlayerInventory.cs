using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    private float money;
    public int playerFruits = 0;
    public List<GameObject> inventoryFruits;
    public GameObject visualInventory; 

    private GameObject fridge;

    private void Start()
    {
    }

    public void addFruitToInventory()
    {
        if (playerFruits  < 3)
        {
          playerFruits++;
        }
    }


    public void hidePlayerInventory()
    {
        visualInventory.SetActive(false);

        foreach (GameObject fruit in inventoryFruits)
        {
            fruit.SetActive(false);
        }
    }

    public void showPlayerInventory()
    {
        visualInventory.SetActive(true);

        foreach (GameObject fruit in inventoryFruits)
        {
            fruit.SetActive(true);
        }
    }

    private void Update()
    {
        foreach (GameObject fruit in inventoryFruits)
        {
            if (fruit.GetComponent<Draggable>().isOnBlender == true)
            {
                inventoryFruits.Remove(fruit);
                playerFruits--; 
            }
        }
    }
}
