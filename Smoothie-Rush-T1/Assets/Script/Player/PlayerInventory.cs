using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    private float money;
    public int playerFruits = 0;
    public List<GameObject> inventoryFruits;
    public GameObject visualInventory;
    public Transform juiceIP;

    private GameObject fridge;

    private void Start()
    {
    }

    public void addFruitToInventory()
    {
        if (playerFruits  < 3)
        {
          playerFruits++;
        }
    }


    public void hidePlayerInventory()
    {
        visualInventory.SetActive(false);

        foreach (GameObject fruit in inventoryFruits)
        {
            fruit.SetActive(false);
        }
    }

    public void showPlayerInventory()
    {
        visualInventory.SetActive(true);

        foreach (GameObject fruit in inventoryFruits)
        {
            fruit.SetActive(true);
        }
    }

    private void Update()
    {
        foreach (GameObject fruit in inventoryFruits)
        {
            if (fruit.GetComponent<Draggable>().isOnBlender == true)
            {
                GameObject.FindWithTag("CodeBlender").GetComponent<smoothieMaker>().fruitsOnBlender.Add(fruit);
                inventoryFruits.Remove(fruit);
                playerFruits--;
                break;
            }
        }

        

    }

    public void renderClientJuice()
    {
        for (int i = 0; i<1; i++)
        {
            if (GameObject.FindWithTag("Glass").GetComponentInParent<JuiceGlass>().isReady == true)
            {
                GameObject clientGlass = Instantiate(GameObject.FindWithTag("Glass"), juiceIP.position, Quaternion.identity);
                clientGlass.gameObject.tag = "clientJuice";
                clientGlass.layer = LayerMask.NameToLayer("JuiceSprite");
                clientGlass.GetComponent<SpriteRenderer>().sortingLayerName = "Character";
                clientGlass.transform.parent = juiceIP.parent;
                Vector3 objectScale = clientGlass.transform.localScale;
                clientGlass.transform.localScale = new Vector3(objectScale.x * 0.35F, objectScale.y * 0.35F, objectScale.z * 0.4F);
                break;
            }
        }
        
    }


    

}
