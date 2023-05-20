using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderTable : MonoBehaviour
{
    public GameObject perfect;
    public GameObject good;


    [SerializeField] private LayerMask DropLayer;
    [SerializeField] private Transform dropZonePoint;
    public float dropZoneRange = 100;
    public Collider2D[] colliderInt = new Collider2D[3];
    public int glassFound;

    // Start is called before the first frame update
    void Start()
    {
        perfect.SetActive(false);
        good.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void ServeJuice()
    {
        glassFound = Physics2D.OverlapCircleNonAlloc(dropZonePoint.position, dropZoneRange, colliderInt, DropLayer);
        if (glassFound == 1)
        {
            GameObject glassOrder = Instantiate(colliderInt[0].gameObject, transform.position, Quaternion.identity);
            glassOrder.GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Character";
            glassOrder.gameObject.tag = "servedJuice";
            Destroy(GameObject.FindWithTag("clientJuice"));
            Vector3 objectScale = glassOrder.transform.localScale;
            glassOrder.transform.localScale = new Vector3(objectScale.x * 30F, objectScale.y * 30F, objectScale.z * 30F);
            
            if (glassOrder.GetComponentInChildren<JuiceStatus>().status == "Perfect")
            {
                perfect.SetActive(true);
            }
            else
            {
                good.SetActive(true);
            }

        }
    }




    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(dropZonePoint.position, dropZoneRange);
    }
}
