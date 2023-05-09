using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float timer = 1f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private bool canSpawn = true;
    [SerializeField] public GameObject player;
   
    

    private void Start()
    {
        StartCoroutine(Spawner());            
    }

    private void FixedUpdate()
    {
        if(GameManager.instance.enemyCounter <= 1)
        {
            canSpawn = false;
        }
    }
    private IEnumerator Spawner()       //Spawner that spawns enemy based on timer
    {
        WaitForSeconds wait = new WaitForSeconds(timer);

        while (canSpawn) 
        {
            yield return wait;
            Instantiate(enemyPrefab, transform.position, Quaternion.identity); //Create enemy
            
           

            
        }
        
    }

}
