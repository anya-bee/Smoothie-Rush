using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fridgeInventory : MonoBehaviour
{
    [SerializeField] public GameObject[] emptySpace;
    [SerializeField] private int fruitQuantity;
    public fridgeFruit[] fruits;

    [System.Serializable]
    public class fridgeFruit
    {
        public GameObject fruitPrefab;
        public int fruitAmount;
    }

    private void fillFridge()
    {
        for(int i = 0; i< fruits.Length; i++)
        {
            GameObject newFruit = Instantiate(fruits[i].fruitPrefab, emptySpace[i].transform.position, Quaternion.identity);
        }
    }

    private void Start()
    {
        fillFridge(); 
    }


}
