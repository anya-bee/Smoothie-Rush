using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    public Sprite emptyGlass;

    public GameObject glass;

    float T;
    bool changesprite = false;
    bool startTimer = false;


    int orange = 0;
    int strawberry = 0;
    int banana = 0;
    int pitahaya = 0;

    public string result;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(startTimer)
            timer();
        if (changesprite)
        {
            UpdateSprite();
            
        }
        fillGlassFruitsArray();
    }

    private void timer()
    {
        T=T+Time.fixedDeltaTime;
        if (T > 10)
        {
            T = 0;
            changesprite=true;
            startTimer = false;
        }
    }


    public void fillGlassFruitsArray()
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
        startTimer = true;


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


    }

    public void UpdateSprite()
    {

        if (orange > 1)
        {
            glass.GetComponentInChildren<SpriteRenderer>().sprite = orangeJuiceSprite;
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
        changesprite = false;

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
                result = "Perfect";
                GetComponentInChildren<JuiceStatus>().status = result;
                GetComponentInChildren<JuiceStatus>().isReady = true;


            }
            else
            {
                nomatched += 1;
                result = "Good";
                GetComponentInChildren<JuiceStatus>().status = result;
                GetComponentInChildren<JuiceStatus>().isReady = true;
            }
        }
       
        Debug.Log("matched fruits : " + matched);

        
    }

    public void cleanUpSprite()
    {
        this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = emptyGlass;
    }
}
