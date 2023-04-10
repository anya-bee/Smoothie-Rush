using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour
{

    Vector3 mousePositionOffset;

    public Vector3 starterPos;
    public bool onMouseUp = false;
    public bool isOnInventory = false;
    public bool isOnBlender = false; 


    private void Start()
    {
        starterPos = transform.position;
    }
    private Vector3 GetMouseWorldPosition()
    {
        //capture mouse posiiton and return WorldPoint
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


    private void OnMouseDown()
    {
        // capture mouse offset 
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition() ; 
    }

    private void OnMouseDrag()
    {
        if (isOnInventory == false)
        {
            transform.position = GetMouseWorldPosition() + mousePositionOffset;
        }

        if (GameObject.FindWithTag("Blender").GetComponent<Blender>().blenderMode == true)
        {
            isOnInventory = false; 
        }
        
    }

    private void OnMouseUp()
    {
        onMouseUp = true;
        transform.position = starterPos;
   
    }


}
