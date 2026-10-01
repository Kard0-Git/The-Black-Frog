using UnityEngine;

public class BossHealthScript : MonoBehaviour
{
 
 WaveOneBossAi BossAI;
GameTextHandler GameUI;

HealthScript health;
HungerBarDecriment hunger;

bool AllowSpeedIncrease = false;

public float SpeedIncreaseAmount;


 public float BossTakesDmg(float dmg)
    {

        Vector3 HealthBarSize = transform.localScale;

        HealthBarSize.x -= dmg;

        transform.localScale = HealthBarSize;

        BossAI = FindAnyObjectByType<WaveOneBossAi>();


        if(transform.localScale.x <= 1.8f)
        {
            if (!AllowSpeedIncrease)
            {
                AllowSpeedIncrease = true;
                BossAI.IncreaseBossSpeed(SpeedIncreaseAmount);
            }
           
        }


        if(transform.localScale.x <= 0)
        {
            transform.localScale = new Vector3(0,1,1);


            BossAI.KillBoss();

   //Enable menu pop up when and disable boss text
            GameUI = FindAnyObjectByType<GameTextHandler>();

            GameUI.DisableBossText();
            GameUI.EnableUpgradesMenu();

            hunger = FindAnyObjectByType<HungerBarDecriment>();

            hunger.TurnOffHungerfunction();


            
        }
   // If the boss gets to half health
   
        return dmg;
    }

}
