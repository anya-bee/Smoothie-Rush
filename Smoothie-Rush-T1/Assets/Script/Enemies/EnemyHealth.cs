using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    //ATRIBUTOS
    public float currentLifeAmount;
    public float maxLifeAmount;
    public bool isDead;



    private void Start()
    {
        currentLifeAmount = maxLifeAmount;
    }

    private void Update()
    {
    }

    //METODOS
    public void Damage(float amount)
    {
        currentLifeAmount -= amount;

        if (currentLifeAmount <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentLifeAmount += amount;

        if (currentLifeAmount > maxLifeAmount)
        {
            currentLifeAmount = maxLifeAmount;
        }
    }

    protected void Die()
    {
        isDead = true;
        Destroy(this.gameObject);
    }
}
