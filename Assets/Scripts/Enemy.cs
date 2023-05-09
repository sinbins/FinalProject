using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 1.5f;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void TakeDamage(float damageAmount)                //Enemy takes damage function(if health is under 0, enemy is defeated and enemy counter is lower)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            
            Defeated();
         
        }
    }

    public void Defeated()
    {
      
        animator.SetTrigger("Defeated");
    }

    public void RemoveEnemy()
    {
        GameManager.instance.enemyCounter--;
        Destroy(gameObject);
    }

  
}
