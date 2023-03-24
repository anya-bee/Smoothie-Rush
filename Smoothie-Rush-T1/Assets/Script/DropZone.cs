using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{

    [SerializeField] private LayerMask DropLayer;
    [SerializeField] private Transform dropZonePoint;
    [SerializeField] private float dropZoneRange = 0.5f;
    [SerializeField] private GameObject Player; 
    private readonly Collider2D[] colliderInt = new Collider2D[3];
    private int fruitFound; 

    public bool fruitInRange; 

    // Start is called before the first frame update
    void Start()
    {
        fruitInRange = false; 
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
                GameObject newFruit = Instantiate(colliderInt[0].gameObject, dropZonePoint.position, Quaternion.identity);
                newFruit.GetComponent<Draggable>().isOnInventory = true;
                
            }
            colliderInt[0].GetComponent<Draggable>().onMouseUp = false; 


        }
        else
        {
            fruitInRange = false; 
        }
    }
}
