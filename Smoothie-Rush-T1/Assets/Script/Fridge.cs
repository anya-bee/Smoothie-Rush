using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Fridge : MonoBehaviour
{

    [SerializeField] private int fridgeFruits = 10;
    [SerializeField] private PlayerInventory playerInventory; 
    [SerializeField] private int playerFruits;
    public string fruitType; 

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();

    }

    private void Update()
    {
        playerFruits = playerInventory.playerFruits;
    }

    public void decreaseFruit()
    {
        if ( fridgeFruits > 0 && playerFruits < 4)
        {
           
            fridgeFruits--;
        }
        
    }
}
