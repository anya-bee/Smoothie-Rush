using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class NpcInteractibles : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey;


    [HideInInspector] public bool playerInRange;
    [SerializeField] private float interactRange = 0.5f;
    [SerializeField]  private Transform interactPoint;
    [SerializeField]  private LayerMask Player;
    [SerializeField] private int interactiblesFound;
    private readonly Collider2D[] colliderInt = new Collider2D[3];

    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private TextAsset DrinkReady;


    public bool orderIsReady = false;

    public List<string> NPC_Order;
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
            if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying) {
                if (Input.GetKeyDown(interactKey))
                {
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                }
                if (Input.GetKeyDown(interactKey) && orderIsReady)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(DrinkReady);
                }


            }
        }
        else
        {
            playerInRange = false;
        }

    }

    public void orderReady()
    {
        orderIsReady = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(interactPoint.position, interactRange);
    }

    


}
