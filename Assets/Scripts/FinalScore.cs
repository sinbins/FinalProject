using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FinalScore : MonoBehaviour
{
    public Text finalScore;
    // Start is called before the first frame update
    void Start()
    {
        finalScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        finalScore.text = "Golem's destroyed: " + GameManager.instance.enemiesDestroyed;
    }

    
}
