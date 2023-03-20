using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour
{

    Vector3 mousePositionOffset;


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
        transform.position = GetMouseWorldPosition() + mousePositionOffset; 
    }


}
