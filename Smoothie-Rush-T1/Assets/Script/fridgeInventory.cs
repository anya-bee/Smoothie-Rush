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

    [System.Serializable]
    public class fridgeFruit 
    {
        public GameObject fruitPrefab;
        public int fruitAmount;

        public void decreaseFruit()
    {
        fruitAmount--; 
    }
    }

    private void fillFridge()
    {
        for(int i = 0; i< fruits.Length; i++)
        {
            GameObject newFruit = Instantiate(fruits[i].fruitPrefab, emptySpace[i].transform.position, Quaternion.identity);
            newFruit.SetActive(true);
            fridgeFruits.Add(newFruit);
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

    private void Start()
    {
        fillFridge(); 
    }

    
    

}
