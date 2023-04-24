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
    public List<GameObject> fruitsOnBlender;
    private float fruitLerpSpeed = 2;
    public Animator animator;
    public GameObject button;

    public GameObject juiceRender;
    public bool smoothieBeingMade;
    
    private void Start()
    {
        button.SetActive(false);
    }


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
            button.SetActive(true);
            animator.SetBool("closed", true);
            changeJuiceColor();
        }

        if  (smoothieBeingMade)
        {
            RemoveFruits();
        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactPoint.position, interactRange);
    }

    public void RemoveFruits()
    {
        foreach (GameObject fruit in fruitsOnBlender)
        {
            fruit.SetActive(false);
            fruitsOnBlender.Remove(fruit);
            break;
        }
    }

    public void hideBlenderFruits()
    {

        foreach (GameObject fruit in fruitsOnBlender)
        {
            
            break;
        }
    }


    public void makeSmoothieOrder()
    {
        smoothieBeingMade = true; 
        animator.SetBool("makeSmoothie", true);
    }

    public void changeJuiceColor()
    {
        int orange = 0;
        int strawberry = 0;
        int banana = 0;
        int pitahaya = 0;
        foreach (GameObject fruit in fruitsOnBlender)
        {
            if (fruit.GetComponent<Fruit>().fruitType == "Orange")
            {
                orange =+ 1;
            }

            if (fruit.GetComponent<Fruit>().fruitType == "Strawberry")
            {
                strawberry =+ 1;
            }

            if (fruit.GetComponent<Fruit>().fruitType == "Banana")
            {
                banana =+ 1;
            }

            if (fruit.GetComponent<Fruit>().fruitType == "Pitahaya")
            {
                pitahaya =+ 1;
            }
        }
        if (orange >= 1)
        {
            juiceRender.GetComponent<SpriteRenderer>().color = Color.cyan;
        }

        if (strawberry >= 1)
        {
            juiceRender.GetComponent<SpriteRenderer>().color = Color.red;
        }

        if (banana >= 1)
        {
            juiceRender.GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        if (pitahaya >= 2)
        {
            juiceRender.GetComponent<SpriteRenderer>().color = Color.magenta;


        }
    }



}
