using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class GameTextHandler : MonoBehaviour
{
   public TMP_Text AmmoText;

   public TMP_Text EnemiesText;

   public GameObject GameOverText;

   int StartingAmmo = 0;

   int EnemyCounter;

   HealthScript health;
   HungerBarDecriment hunger;

   void Start()
    {
        //disables Gameover text and button as I have made the restart button a child of the gameover text
      GameOverText.SetActive(false);
      health = FindAnyObjectByType<HealthScript>();
      hunger = FindAnyObjectByType<HungerBarDecriment>();
      
    }

   
   public void UpdateAmmo()
    {
        StartingAmmo++;

        AmmoText.text = $"Ammo: {StartingAmmo}";
    }

  public void DecrimentAmmo()
    {
        StartingAmmo--;

        AmmoText.text = $"Ammo: {StartingAmmo}";

        if(StartingAmmo <= 0)
        {
            AmmoText.text = "Ammo: Get more ammo >:[";
        }
    }

  public void CountEnemies()
    {
        EnemyCounter++;

        EnemiesText.text = $"Enemies: {EnemyCounter}";
    }

 public void DecrimentEnemyCounter()
    {
        EnemyCounter--;

        EnemiesText.text = $"Enemies: {EnemyCounter}";
    }

 public void ShowGameOverScreen()
    {
        GameOverText.SetActive(true);
        hunger.TurnOffHungerfunction();
        health.StopTakingDmg();
    }
 
}
