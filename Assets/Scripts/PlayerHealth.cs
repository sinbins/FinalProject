using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;


public class PlayerHealth : MonoBehaviour
{
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] 
    Image healthBar;
    public Gradient healthBarColor;
    private void Start()
    {
        health = maxHealth;
        healthBar.color = healthBarColor.Evaluate(health / maxHealth);
    }

    public void UpdateHealth(float mod)
    {
        health += mod;
        healthBar.fillAmount = health/maxHealth;
        healthBar.color = healthBarColor.Evaluate(health / maxHealth);
        if(health <= 0)
        {
            health = 0f;
            SceneManager.LoadScene(2);
            
            
        }
    }
}
