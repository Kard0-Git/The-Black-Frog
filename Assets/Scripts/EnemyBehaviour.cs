
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

   HealthScript PlayerHealth;

   public float SmallEnemiesDmg;

  
void Start()
    {
      frogPlayer = FindAnyObjectByType<FrogMovenment>();
      GameText = FindAnyObjectByType<GameTextHandler>();
      FindAnyObjectByType<AudioManager>().PlaySounds("FlySound");

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
            FindAnyObjectByType<AudioManager>().PlaySounds("EnemyDeath");

        }

        if(collision.gameObject.tag == "Player")
        {
            PlayerHealth = FindAnyObjectByType<HealthScript>();

            PlayerHealth.TakeDamageFromEnemy(SmallEnemiesDmg);

            
            FindAnyObjectByType<AudioManager>().PlaySounds("EnemyDeath");
        }

    }

}
