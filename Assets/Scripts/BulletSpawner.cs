using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BulletSpawner : MonoBehaviour
{
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


//spawn a bullet only when
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
         SpawnBullets();

        }

        if (Input.GetKeyDown(KeyCode.E))
        {

            EatBullets();


        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            animator.SetBool("IsEating",false);
        }
    }

  
    public void AddBullets()
    {
        AmmoCollection.Add(Bullet);
    }
//SpawnBullets if there are bullets in our array and only if the RMB is pressed
    public void SpawnBullets()
    {
        //Only Fire a shot after the cooldown
        if(Time.time - lastShotFired < cooldown)
        {
            return;
        }

       if(CheckforRange == false)
        {
          lastShotFired = Time.time;
             for(int i = 0; i<AmmoCollection.Count; i++)
        {
            Instantiate(AmmoCollection[i],transform.position,transform.rotation,BulletsFired);
        }
       
        AmmoCollection.RemoveAt(AmmoCollection.Count - 1);
        ammoText.DecrimentAmmo();
        FindAnyObjectByType<AudioManager>().PlaySounds("ShootBin");


        }

        if(AmmoCollection.Count <= 0)
        {
            CheckforRange = true;
          

        } else
        {
            CheckforRange = false;
        }


       
        // remove bullets from the array once spawned so that you effectively run out of bullets to shoot

    }

 void EatBullets()
    {
       if(CheckforRange == false)
        {
         AmmoCollection.RemoveAt(AmmoCollection.Count - 1 );
         ammoText.DecrimentAmmo();
         hungerBar.RefillHunger();
         FindAnyObjectByType<AudioManager>().PlaySounds("ChewingAmmo");
         animator.SetBool("IsEating",true);


         AddOnHealth = FindAnyObjectByType<HealthScript>();

         Upgrades = FindAnyObjectByType<UpgradeHandler>();

         AddOnHealth.GainHealth();
   
        }

 
        if(AmmoCollection.Count <= 0)
        {
            CheckforRange = true;

          

        } else
        {
            CheckforRange = false;
        }


        
    }

    
}
