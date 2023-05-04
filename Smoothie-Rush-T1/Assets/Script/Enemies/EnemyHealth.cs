using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //ATRIBUTOS
    private float currentLifeAmount;
    public float maxLifeAmount;



    private void Start()
    {
        currentLifeAmount = maxLifeAmount;
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
        Destroy(this.gameObject);
    }
}
