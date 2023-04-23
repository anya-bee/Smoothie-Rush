using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class NpcInteractibles : MonoBehaviour
{
    [SerializeField] private GameObject interactAction;
    [SerializeField] private KeyCode interactKey;


    [HideInInspector] public bool playerInRange;
    [SerializeField] private float interactRange = 0.5f;
    [SerializeField]  private Transform interactPoint;
    [SerializeField]  private LayerMask Player;
    [SerializeField] private int interactiblesFound;
    private readonly Collider2D[] colliderInt = new Collider2D[3];

    [SerializeField] private TextAsset inkJSON;

    public List<GameObject> npcOrder;

    private void Start()
    {

        playerInRange = false;
        interactAction.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        interactiblesFound = Physics2D.OverlapCircleNonAlloc(interactPoint.position, interactRange, colliderInt, Player); 
        if (interactiblesFound == 1)
        {
            playerInRange = true;
            interactAction.SetActive(true);
            if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying) {
                if (Input.GetKeyDown(interactKey))
                {
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);

                }
            }
        }
        else
        {
            playerInRange = false;
            interactAction.SetActive(false); 
        }


    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(interactPoint.position, interactRange);
    }


}
