using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float timer = 3f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private bool canSpawn = true;
    [SerializeField] private int enemiesSpawned = 0;
   
    

    private void Start()
    {
        StartCoroutine(Spawner());            
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
