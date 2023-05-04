using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class fridgeInventory : MonoBehaviour
{
    [SerializeField] public GameObject[] emptySpace;

    public fridgeFruit[] fruits;
    public List<GameObject> fridgeFruits;
    public int[] quantityPerFruit;

    [System.Serializable]
    public class fridgeFruit 
    {
        public GameObject fruitPrefab;
        public int fruitAmount;

        public void decreaseFruit()
    {
        fruitAmount--; 

    }
        public void setFruitAmount(int q)
        {
            fruitAmount = q;
        }
    }

    private void fillFridge()
    {
        for(int i = 0; i< fruits.Length; i++)
        {
            GameObject newFruit = Instantiate(fruits[i].fruitPrefab, emptySpace[i].transform.position, Quaternion.identity);
            newFruit.SetActive(true);
            fridgeFruits.Add(newFruit);
            fruits[i].setFruitAmount(2) ;
        }
    }

    public void hideFridge()
    {

        this.gameObject.SetActive(false);

        foreach (GameObject fruit in fridgeFruits)
        {
            fruit.SetActive(false);
        }

    }

    public void showFridge()
    {

        this.gameObject.SetActive(true);

        foreach (GameObject fruit in fridgeFruits)
        {
            fruit.SetActive(true);
        }

    }

    internal void RestarFruta(string nfrutarecibida)
    {
        

        if (nfrutarecibida == "Orange")
            fruits[0].decreaseFruit();

        else if (nfrutarecibida == "Banana")
            fruits[1].decreaseFruit();

        else if (nfrutarecibida == "Strawberry")
            fruits[2].decreaseFruit();

        else if (nfrutarecibida == "Pitahaya")
            fruits[3].decreaseFruit();
    }

    private void Start()
    {
        fillFridge(); 
    }

    
    

}
