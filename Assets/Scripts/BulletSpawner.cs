using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BulletSpawner : MonoBehaviour
{
    private static readonly int IsPuffedUpHash = Animator.StringToHash("IsPuffedUp");
    private static readonly int IsEatingHash = Animator.StringToHash("IsEating");
    public float cooldown;

 public float lastShotFired;

  public GameObject Bullet;
  public List<GameObject> AmmoCollection;

  public Transform BulletsFired;

  bool CheckforRange = false;

  GameTextHandler ammoText;

  HungerBarDecriment hungerBar;

  Animator animator;

  HealthScript AddOnHealth;

  UpgradeHandler Upgrades;
  

  public Button UpgradeOneButton;

  void Start()
    {
        ammoText = FindAnyObjectByType<GameTextHandler>();
        hungerBar = FindAnyObjectByType<HungerBarDecriment>();
        animator = FindAnyObjectByType<Animator>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
         SpawnBullets();

        }

//Eat a bullet when the user presses E
        if (Input.GetKeyDown(KeyCode.E))
        {

            EatBullets();
            animator.SetBool(IsPuffedUpHash,false);
            
        }
// stop running animation when the key is released
        if (Input.GetKeyUp(KeyCode.E))
        {
            animator.SetBool("IsEating",false);

            
            animator.SetBool("IsPuffedUp",true);
         

        }
    }

  
    public void AddBullets()
    {
        AmmoCollection.Add(Bullet);
        animator.SetBool("IsPuffedUp",true);
    }
//SpawnBullets if there are bullets in our array and only if the RMB is pressed
    public void SpawnBullets()
    {
        //Only Fire a shot after the cooldown
        if(Time.time - lastShotFired < cooldown)
        {
            return;
        }

 // spawn a bullet for each bullet in the list
       if(CheckforRange == false)
        {
          lastShotFired = Time.time;
             for(int i = 0; i<AmmoCollection.Count; i++)
        {
            Instantiate(AmmoCollection[i],transform.position,transform.rotation,BulletsFired);
            
        }
       
       //Every time we shoot a bullet, remove the last bullet in the array
        AmmoCollection.RemoveAt(AmmoCollection.Count - 1);
        // display it on screen
        ammoText.DecrimentAmmo();
        //Play the sound clip
        FindAnyObjectByType<AudioManager>().PlaySounds("ShootBin");


        }

// if we have no bullets in the array, stop spawning them
        if(AmmoCollection.Count <= 0)
        {
            CheckforRange = true;
            animator.SetBool("IsPuffedUp",false);
          

        } else
        {
            CheckforRange = false;
        }

    }

 void EatBullets()
    {
        // remove bullets fron the array and fill hunger bar when we have eaten one
       if(CheckforRange == false)
        {
         AmmoCollection.RemoveAt(AmmoCollection.Count - 1 );
         ammoText.DecrimentAmmo();
         hungerBar.RefillHunger();
         FindAnyObjectByType<AudioManager>().PlaySounds("ChewingAmmo");
         animator.SetBool(IsEatingHash,true);

         

// Gain health upgrade logic
         AddOnHealth = FindAnyObjectByType<HealthScript>();

         Upgrades = FindAnyObjectByType<UpgradeHandler>();

         AddOnHealth.GainHealth();
   
        }

 // check again if we are out of bullets. If so do not spawn
        if(AmmoCollection.Count <= 0)
        {
            CheckforRange = true;

          
// otherwise allow us to shoot ammo
        } else
        {
            CheckforRange = false;
        }


        
    }


}
