using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceGlass : MonoBehaviour
{

    public string[] glassFruits = new string[3];

    public Sprite orangeJuiceSprite;
    public Sprite strawberryJuiceSprite;
    public Sprite bananaJuiceSprite;
    public Sprite pitahayaJuiceSprite;


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
            this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = orangeJuiceSprite;
        }

        if (strawberry > 1)
        {
            this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = strawberryJuiceSprite; 
        }

        if (banana > 1)
        {
            this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = bananaJuiceSprite;
        }

        if (pitahaya > 1)
        {
            this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = pitahayaJuiceSprite;
        }
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

        
    }
}
