using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [HideInInspector] public bool playerInRange;
    [SerializeField] private float interactRange = 0.5f;
    [SerializeField] private Transform interactPoint;
    [SerializeField] private LayerMask Enemy;
    [SerializeField] private int interactiblesFound;
    private readonly Collider2D[] colliderInt = new Collider2D[3];

    float T;
    bool attack = false;
    bool startTimer = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
            timer();
        interactiblesFound = Physics2D.OverlapCircleNonAlloc(interactPoint.position, interactRange, colliderInt, Enemy);
        if (interactiblesFound == 1)
        {
            startTimer = true;

            if (attack)
                enemyAttack();
        }
        else
        {
            T = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactPoint.position, interactRange);
    }

    void enemyAttack()
    {
        colliderInt[0].gameObject.GetComponent<HealthComponent>().Damage(10f);
        attack = false;
    }
    private void timer()
    {
        T = T + Time.fixedDeltaTime;
        if (T > 30)
        {
            T = 0;
            attack = true;
            startTimer = false;
        }
    }
}
