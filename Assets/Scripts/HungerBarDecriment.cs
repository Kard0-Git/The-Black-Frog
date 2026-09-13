using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class HungerBarDecriment : MonoBehaviour
{

    public float ScaleRate;

    HealthScript health;

    public float DamageToHealth;

    bool TurnOfHunger = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = FindAnyObjectByType<HealthScript>();
    }

    // Update is called once per frame
    void Update()
    {
      
        DecrimentHungerBar();
        StopScalingHunger();
        
       
    }

    void DecrimentHungerBar()
    {
        if (!TurnOfHunger)
        {
        Vector2 NewScale = transform.localScale;

        NewScale.x -= Time.deltaTime * ScaleRate;

        transform.localScale = NewScale;

        }
        
        
    }

    void StopScalingHunger()
    {
        if (!TurnOfHunger)
        {
        if(transform.localScale.x <= 0)
        {
            Vector2 newSize = transform.localScale;
            newSize.x = 0;

            transform.localScale = newSize;

            health.TakeDamage(DamageToHealth);
        }
        }
      
    }

    public void RefillHunger()
    {
        if (!TurnOfHunger)
        {
        Vector2 BacktoFull = transform.localScale;

        BacktoFull.x = 1;

        transform.localScale = BacktoFull;
        }
 
    }

    public void TurnOffHungerfunction()
    {
        TurnOfHunger = true;
    }
}
