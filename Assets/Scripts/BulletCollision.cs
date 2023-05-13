 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BulletCollision : MonoBehaviour
{
    

    


    private void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            GameManager.instance.vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 5;
            SoundManager.instance.PlayAudio(1);
            enemyComponent.TakeDamage(1);
        }

        Destroy(gameObject);
        
    }

    private void FixedUpdate()
    {
        GameManager.instance.vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
    }


}
