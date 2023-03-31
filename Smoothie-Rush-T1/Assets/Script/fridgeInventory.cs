using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class fridgeInventory : MonoBehaviour
{
    [SerializeField] public GameObject[] emptySpace;

    public fridgeFruit[] fruits;

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

        }
    }

    public void hideFridge()
    {

        foreach (fridgeFruit fruit in fruits)
        {
            fruit.fruitPrefab.gameObject.SetActive(false);
        }

    }

    public void showFruit()
    {

        foreach (fridgeFruit fruit in fruits)
        {
            fruit.fruitPrefab.gameObject.SetActive(true);
        }

    }

    private void Start()
    {
        fillFridge(); 
    }

    
    

}
