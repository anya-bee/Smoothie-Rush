using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceGlass : MonoBehaviour
{

    public string[] glassFruits = new string[3];
    public bool isReady = false; 

    public Sprite orangeJuiceSprite;
    public Sprite strawberryJuiceSprite;
    public Sprite bananaJuiceSprite;
    public Sprite pitahayaJuiceSprite;
    public Sprite defaultJuice;

    public GameObject glass;


    void Start()
    {
        
    }

    
    void Update()
    {
        fillGlassFruitsArray();  
    }


    private void fillGlassFruitsArray()
    {
        glassFruits = GameObject.FindWithTag("CodeBlender").GetComponent<smoothieMaker>().fruitsArray;

    }

    public void juiceIsReady()
    {
        isReady = true;
        GameObject.FindWithTag("Player").GetComponent<PlayerInventory>().renderClientJuice();

    }

    public void changeJuiceSprite()
    {

        int orange = 0;
        int strawberry = 0;
        int banana = 0;
        int pitahaya = 0;


        foreach (string fruitname in glassFruits)
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
            glass.GetComponent<SpriteRenderer>().sprite = orangeJuiceSprite;
            Debug.Log("orange juice");
        }
        
        else if (strawberry > 1)
        {
            this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = strawberryJuiceSprite;
            Debug.Log("strawberry juice");
        }

        else if (banana > 1)
        {
            this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = bananaJuiceSprite;
            Debug.Log("banana juice");
        }

        else if (pitahaya > 1)
        {
            this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = pitahayaJuiceSprite;
            Debug.Log("pitahaya juice");
        }
        else
        {
            this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = defaultJuice;
            Debug.Log("fruit juice");
        }
        
        juiceIsReady();
    }


    public void checkOrder()
    {
        int matched = 0;
        int nomatched = 0;

        for (int i = 0; i < 3; i++)
        {
            if ( glassFruits[i] == GameObject.FindWithTag("Manager").GetComponent<DialogueManager>().npcOrder[i])
            {
                matched += 1;
            }
            else
            {
                nomatched += 1;
            }
        }
        Debug.Log("matched fruits : " + matched);

        
    }
}
