using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{


    FrogMovenment frogPlayer;

    public float EnemySpeed;

    bool StopPlayerTracking = false;

    GameTextHandler GameText;




void Start()
    {
      frogPlayer = FindAnyObjectByType<FrogMovenment>();
      GameText = FindAnyObjectByType<GameTextHandler>();

    }
  void Update()
    {
       
         MoveEnemy();

    }

    void MoveEnemy()
    {
  // If the frog exists, Move towards the frog over time (this increases as the speed of the enemy increases)
        if (frogPlayer != null)
        {
             float step = EnemySpeed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position,frogPlayer.transform.position,step);
          
        }
     
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
     
            Destroy(collision.gameObject);
            Destroy(gameObject);
         

        }

        if(collision.gameObject.tag == "Player")
        {
            if(frogPlayer != null)
            Destroy(collision.gameObject);
            GameText.ShowGameOverScreen();
        }


    }




    

}
