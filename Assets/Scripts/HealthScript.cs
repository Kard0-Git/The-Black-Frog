using System;
using System.Threading;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public float DamageTimer;

    public float tickspeed;

    bool StopDamageTimer = false;

    FrogMovenment frog;
    GameTextHandler Gameoverscreen;

 

// Get the frog script so we can delete it
    void Start()
    {
        DamageTimer = tickspeed;
        Gameoverscreen = FindAnyObjectByType<GameTextHandler>();
     
    }
    void Update()
    {
        
        HealthAtZero();
    }

    //Take damage every couple seconds
   public float TakeDamage(float damage)
    {
        if (!StopDamageTimer)
        {
             DamageTimer -= Time.deltaTime;

        if(DamageTimer <= 0)
        {
        Vector2 UpdateHealth = transform.localScale;

        UpdateHealth.x -= damage;

        transform.localScale = UpdateHealth;

        DamageTimer = tickspeed;
        }

        }
       
        
        return damage;
    }

  //When our health gets to 0, stop taking damage, kill the player and make sure the health stays at 0 unless otherwise stated
    void HealthAtZero()
    {
        if(transform.localScale.x <= 0f)
        {
            //Only kill the frog if it has a type still
            frog = FindAnyObjectByType<FrogMovenment>();

            if(frog != null)
            {
              frog.KillPlayer();
              Gameoverscreen.ShowGameOverScreen();

            }


            Vector2 NewHealth = transform.localScale;

            NewHealth.x = 0;

            transform.localScale = NewHealth;
// So we stop taking damage when we get to 0
            StopDamageTimer = true;


        }
    }

    public void StopTakingDmg()
    {
        StopDamageTimer = true;
    }

    
}
