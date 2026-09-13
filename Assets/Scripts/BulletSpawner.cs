using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
  public float cooldown;

  public float tickspeed;

  public GameObject Bullet;
  public List<GameObject> AmmoCollection;

  public Transform BulletsFired;

  bool CheckforRange = false;

  GameTextHandler ammoText;

  HungerBarDecriment hungerBar;

  void Start()
    {
        ammoText = FindAnyObjectByType<GameTextHandler>();
        hungerBar = FindAnyObjectByType<HungerBarDecriment>();
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
    }

  
    public void AddBullets()
    {
        AmmoCollection.Add(Bullet);
    }
//SpawnBullets if there are bullets in our array and only if the RMB is pressed
    public void SpawnBullets()
    {
        
       if(CheckforRange == false)
        {
             for(int i = 0; i<AmmoCollection.Count; i++)
        {
            Instantiate(AmmoCollection[i],transform.position,transform.rotation,BulletsFired);
        }
       
        AmmoCollection.RemoveAt(AmmoCollection.Count - 1);
        ammoText.DecrimentAmmo();


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
       AmmoCollection.RemoveAt(AmmoCollection.Count - 1 );
       ammoText.DecrimentAmmo();

       hungerBar.RefillHunger();

       
        if(AmmoCollection.Count <= 0)
        {
            CheckforRange = true;
          

        } else
        {
            CheckforRange = false;
        }


        
    }
}
