using UnityEngine;

public class SpawnBossEnemy : MonoBehaviour
{
public GameObject BossPrefab;
public Transform EnemyHolder;
public GameObject BossHealthBar;
FrogMovenment frogPlayer;
public bool StopBossSpawning;

 void Start()
    {
        BossHealthBar.SetActive(false);
      
    }

public void SpawnBoss()
    {


FindAnyObjectByType<AudioManager>().PlaySounds("BossMusic");


      BossHealthBar.SetActive(true);
      
      if(StopBossSpawning == false)
      
        {

        Instantiate(BossPrefab,transform.position,Quaternion.identity);
       
        
        }
    
    }
}
