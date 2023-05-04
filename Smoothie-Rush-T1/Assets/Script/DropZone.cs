using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{

    [SerializeField] private LayerMask DropLayer;
    [SerializeField] private Transform dropZonePoint;
     private float dropZoneRange = 0.5f;
    public Collider2D[] colliderInt = new Collider2D[3];
    public int fruitFound; 

    public bool fruitInRange;

    [SerializeField] private GameObject player;
    [SerializeField]private fridgeInventory Fridge;

    // Start is called before the first frame update
    void Start()
    {
        fruitInRange = false;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        fruitFound = Physics2D.OverlapCircleNonAlloc(dropZonePoint.position, dropZoneRange, colliderInt, DropLayer); 
        if(fruitFound == 1)
        {
            fruitInRange = true;
            if (colliderInt[0].GetComponent<Draggable>().onMouseUp == true)
            {
                GameObject newFruit =  Instantiate(colliderInt[0].gameObject, dropZonePoint.position, Quaternion.identity);
                newFruit.layer = LayerMask.NameToLayer("Slots");
                player.GetComponent<PlayerInventory>().inventoryFruits.Add(newFruit);
                player.GetComponent<PlayerInventory>().addFruitToInventory();
                Fridge.RestarFruta(newFruit.GetComponent<Fruit>().fruitType);
                newFruit.GetComponent<Draggable>().isOnInventory = true;
                //Debug.Log(colliderInt[0].GetComponent<fridgeInventory.fridgeFruit>().fruitAmount); 
    
            }
            colliderInt[0].GetComponent<Draggable>().onMouseUp = false;
        }
        else
        {
            fruitInRange = false; 
        }
    }


    public void hideSlots()
    {
        this.gameObject.SetActive(false);
    }
}
