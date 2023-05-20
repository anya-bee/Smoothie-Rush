using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey;
    [HideInInspector] public bool playerInRange;
    [SerializeField] private float interactRange = 0.5f;
    [SerializeField] private Transform interactPoint;
    [SerializeField] private LayerMask Enemy;
    [SerializeField] private int interactiblesFound;
    private readonly Collider2D[] colliderInt = new Collider2D[3];

    public Animator animator;

    bool attack = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(interactKey))
        {
            attackinput();
        }
    }
    void attackinput()
    {
        animator.SetTrigger("canAttack");
        
        interactiblesFound = Physics2D.OverlapCircleNonAlloc(interactPoint.position, interactRange, colliderInt, Enemy);
        if (interactiblesFound == 1)
        {
            playerAttack();
        }
      
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactPoint.position, interactRange);
    }

    void playerAttack()
    {
        colliderInt[0].gameObject.GetComponent<EnemyHealth>().Damage(20f);
         
        attack = false;
    }
    
}
