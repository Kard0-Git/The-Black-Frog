using System;
using UnityEngine;

public class BossEnemyRotation : MonoBehaviour
{

bool StopRotation = false;

FrogMovenment frog;
    void Update()
    {
        RotateEnemy();
    } 

// so the enemy looks at the 
    void RotateEnemy()
    {
        if (!StopRotation)
        {
          
            frog = FindAnyObjectByType<FrogMovenment>();

            if(frog != null)
            {
            Vector3 Distance = frog.transform.position - transform.position;

            float angle = Mathf.Atan2(Distance.y,Distance.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0,0,angle);
            }
        }
    }

    public void NoRotation()
    {
        StopRotation = true;
    }

    public void TurnOnRotation()
    {
        StopRotation = false;
    }
}
