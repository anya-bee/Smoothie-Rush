using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float moveSpeed;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    [HideInInspector] public bool playerInRange;
    [SerializeField] private float interactRange = 0.5f;
    [SerializeField] private Transform interactPoint;
    [SerializeField] private LayerMask Player;
    [SerializeField] private int interactiblesFound;
    private readonly Collider2D[] colliderInt = new Collider2D[3];


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        rb.velocity = new Vector2 (0,0);
    }

    // Update is called once per frame
    void Update()
    {
        interactiblesFound = Physics2D.OverlapCircleNonAlloc(interactPoint.position, interactRange, colliderInt, Player);
        if (interactiblesFound == 1)
        {
            moveSpeed = 70;
            if (target)
            {
                Vector3 direction = (target.position - transform.position).normalized;

                moveDirection = direction;
            }
        }
        else
        {
            moveSpeed = 0; 
        }

        
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(interactPoint.position, interactRange);
    }


}
