using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;   
    public int enemiesDestroyed;  //Keep track of how many enemies have been destroyed
    public CinemachineVirtualCamera vc;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
       // enemyCounter = 0;
        enemiesDestroyed = 0;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
