using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class Interactibles : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey;

    public UnityEvent openUI; 

    [HideInInspector] public bool playerInRange;
    [SerializeField] private float interactRange = 0.5f;
    [SerializeField]  private Transform interactPoint;
    [SerializeField]  private LayerMask Player;
    [SerializeField] private int interactiblesFound;
    private readonly Collider2D[] colliderInt = new Collider2D[3];
    [SerializeField] private string objectName; 

    private void Start()
    {

        playerInRange = false;
    }

    // Update is called once per frame
    private void Update()
    {
        interactiblesFound = Physics2D.OverlapCircleNonAlloc(interactPoint.position, interactRange, colliderInt, Player); 
        if (interactiblesFound == 1)
        {
            playerInRange = true;
            if (Input.GetKeyDown(interactKey))
            {
                openUI.Invoke(); 
                Debug.Log(objectName); 

            }
        }
        else
        {
            playerInRange = false;
        }


    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(interactPoint.position, interactRange);
    }


}
