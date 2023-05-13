using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;  //Enemy health
    public Player player;                           //Player reference for following
    [SerializeField] private float speed = 1.5f;   //Speed of enemy
   
    Vector2 movement;                              
    Animator animator;
    Rigidbody2D rb;

    [SerializeField] private float attackDamage = 10f;    //Enemies damage
    [SerializeField] private float attackSpeed = 2;        //Enemies attack speed
    private float canAttack;                            //Cooldown if enemy can attack
    public bool facingRight = false;

   // [SerializeField] CinemachineVirtualCamera vc;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        health = maxHealth;
        rb  = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        
            var direction = player.transform.position - transform.position;      //Get the direction of the player 
            movement = direction;

        if (player.transform.position.x < gameObject.transform.position.x && !facingRight)   //Change facing direction based on player's x position
            Flip();
        if (player.transform.position.x > gameObject.transform.position.x && facingRight)
            Flip();
       
        if(player == null)
            direction = Vector2.zero;

    }


    void Flip()  //Flip's enemy according to player
    {
        
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }
    private void OnCollisionStay2D(Collision2D other)  
    {
        
            if (other.gameObject.tag == "Player")
            {
                if (attackSpeed <= canAttack) //Enemy can attack once the attack speed is less or caught up to canAttack
                {
                    
                        other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);  //Gives damage to player's health
                        animator.SetBool("Attack", true);                                            //Set attack animation
                        canAttack = 0;                                                             //Reset can attack for delay
                    
                }
                else
                {
                    animator.SetBool("Attack", false);    //Can't attack if cooldown is happening
                    canAttack += Time.deltaTime;         //Increase attack time
                }


            }
        
    }


    private void FixedUpdate()
    {
        if (player != null)
        {
            MoveCharacter(movement); //Moves character according to fixed update
        }
       
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
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
        SoundManager.instance.PlayAudio(2);
        GameManager.instance.enemiesDestroyed++;
        Destroy(gameObject);
    }
 
    
}
