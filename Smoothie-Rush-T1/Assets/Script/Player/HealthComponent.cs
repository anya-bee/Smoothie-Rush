using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthComponent : MonoBehaviour
{
    //ATRIBUTOS
    public float currentLifeAmount;
    public float maxLifeAmount;
    public Image LifeBar;


    private void Start()
    {
        currentLifeAmount = maxLifeAmount;
    }

    //METODOS
    public void Damage(float amount)
    {
        LifeBar.fillAmount = currentLifeAmount / maxLifeAmount;
        currentLifeAmount =currentLifeAmount- amount;

        if (currentLifeAmount <= 0)
        {
            currentLifeAmount = maxLifeAmount;
            SceneManager.LoadScene(1);
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