using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class smoothieMaker : MonoBehaviour
{
    [SerializeField] private Transform interactPoint;
    [SerializeField] private LayerMask Slots;
    [SerializeField] private float interactRange = 0.5f;

    private readonly Collider2D[] colliderInt = new Collider2D[3];
    [SerializeField] private int interactiblesFound;

    public List<GameObject> targets;
    private float fruitLerpSpeed = 2;
    public Animator animator;

    private void Update()
    {
        animator.SetBool("closed", false);
        interactiblesFound = Physics2D.OverlapCircleNonAlloc(interactPoint.position, interactRange, colliderInt, Slots);
        if (interactiblesFound == 1)
        {
            colliderInt[0].GetComponent<Transform>().position = Vector3.Lerp(colliderInt[0].GetComponent<Transform>().position, targets[0].transform.position, Time.deltaTime * fruitLerpSpeed);
            colliderInt[0].GetComponent<Draggable>().starterPos = colliderInt[0].GetComponent<Transform>().position;
            colliderInt[0].GetComponent<Draggable>().isOnInventory = true;
            colliderInt[0].GetComponent<Draggable>().isOnBlender = true;

        }

        if (GameObject.FindWithTag("Player").GetComponent<PlayerInventory>().playerFruits == 0)
        {
            animator.SetBool("closed", true); 
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactPoint.position, interactRange);
    }
}
