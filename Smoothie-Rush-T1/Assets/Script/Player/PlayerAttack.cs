using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    private int strawberryEnemy = 0;
    private int bananaEnemy = 0;
    private int orangeEnemy = 0;
    private int pitahayaEnemy = 0;

    [SerializeField] private TextMeshProUGUI strawberryCount;
    [SerializeField] private TextMeshProUGUI bananaCount;
    [SerializeField] private TextMeshProUGUI orangeCount;
    [SerializeField] private TextMeshProUGUI pitahayaCount;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        strawberryCount.text = strawberryEnemy.ToString();
        bananaCount.text = bananaEnemy.ToString();
        orangeCount.text = orangeEnemy.ToString();
        pitahayaCount.text = pitahayaEnemy.ToString();

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
        if (colliderInt[0].gameObject.GetComponent<EnemyAttack>().enemyName == "Strawberry" && colliderInt[0].gameObject.GetComponent<EnemyHealth>().isDead)
        {
            strawberryEnemy += 1;
        }
        else if (colliderInt[0].gameObject.GetComponent<EnemyAttack>().enemyName == "Banana" && colliderInt[0].gameObject.GetComponent<EnemyHealth>().isDead)
        {
            bananaEnemy += 2;
        }
        else if (colliderInt[0].gameObject.GetComponent<EnemyAttack>().enemyName == "Orange" && colliderInt[0].gameObject.GetComponent<EnemyHealth>().isDead)
        {
            orangeEnemy += 1;
        }
        if (colliderInt[0].gameObject.GetComponent<EnemyAttack>().enemyName == "Pitahaya" && colliderInt[0].gameObject.GetComponent<EnemyHealth>().isDead)
        {
            pitahayaEnemy += 2;
        }


        attack = false;
    }
    
}
