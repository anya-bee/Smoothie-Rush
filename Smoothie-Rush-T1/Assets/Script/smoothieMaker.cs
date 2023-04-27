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
    public string[] fruitsArray = new string[3];

    private float fruitLerpSpeed = 2;
    public Animator animator;
    public GameObject button;

    public GameObject juiceRender;
    public bool smoothieBeingMade;

    private int orange = 0;
    private int strawberry = 0;
    private int banana = 0;
    private int pitahaya = 0;

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

            if (GameObject.FindWithTag("Player").GetComponent<PlayerInventory>().playerFruits == 3)
            {
                fruitsArray[0] = colliderInt[0].GetComponent<Fruit>().fruitType;
            }
            if (GameObject.FindWithTag("Player").GetComponent<PlayerInventory>().playerFruits == 2)
            {
                fruitsArray[1] = colliderInt[0].GetComponent<Fruit>().fruitType;
            }
            if (GameObject.FindWithTag("Player").GetComponent<PlayerInventory>().playerFruits == 1)
            {
                fruitsArray[2] = colliderInt[0].GetComponent<Fruit>().fruitType;
            }

        }


        if (GameObject.FindWithTag("Player").GetComponent<PlayerInventory>().playerFruits == 0)
        {
            button.SetActive(true);
            animator.SetBool("closed", true);
        }

        if  (smoothieBeingMade)
        {
            button.SetActive(false);
            HideFruits();
        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactPoint.position, interactRange);
    }

    public void HideFruits()
    {
        foreach (GameObject fruit in fruitsOnBlender)
        {
            fruit.SetActive(false);
            
        }
    }



    public void makeSmoothieOrder()
    {
        smoothieBeingMade = true; 
        animator.SetBool("makeSmoothie", true);
    }

    public void changeJuiceColor()
    {
        Color orangeColor = new Color(255, 116, 46);
        Color pinkColor = new Color(254, 108, 145);
        

        foreach (string fruitname in fruitsArray )
        {
            if (fruitname == "Orange")
            {
                orange += 1;
            }

            if (fruitname == "Strawberry")
            {
                strawberry += 1;
            }

            if (fruitname == "Banana")
            {
                banana += 1;
            }

            if (fruitname == "Pitahaya")
            {
                pitahaya += 1;
            }

        }


       
        if (orange > 1)
        {
            juiceRender.GetComponent<SpriteRenderer>().color = new Color(1, 0.45F, 0.003F, 1);
        }

        if (strawberry > 1)
        {
            juiceRender.GetComponent<SpriteRenderer>().color = Color.red;
        }

        if (banana > 1)
        {
            juiceRender.GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        if (pitahaya > 1)
        {
            juiceRender.GetComponent<SpriteRenderer>().color = new Color(1, 0.35F, 0.69F, 1);
        }


    }



}
