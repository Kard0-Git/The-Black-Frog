using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class WaveOneBossAi : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    public float countdown;
    public float tickRate;
    public float TrackMovenemntTime;
    public float MovenmentTimeTickRate;
    BossEnemyRotation BossRotation;
    BossHealthScript BossHealth;
    GameTextHandler GameOverScreen;
    FrogMovenment frog;

    HealthScript frogHealth;
    public float offset;
    public Vector2 ceiling, floor,Leftwall,Rightwall;

    bool IsBossHit = false;
    bool PlayBossMusic = false;
    public float PlayerBulletDmg;
    public float BossDamage;
    bool IsPlayerHit = false;

    bool PlayRushMoveSound = false;
    bool PlayMosquitoWingSound = false;

    Animator BossAnimations;

    public GameObject BloodSplatter;

   


  void Start()
    {
        countdown = tickRate;
        TrackMovenemntTime = MovenmentTimeTickRate;
        BossAnimations = GetComponentInChildren<Animator>();
       
    }
    
    void Update()
    {
        MoveEnemny();
        BossConstraints();

    }

   void MoveEnemny()
    {
        countdown -= Time.deltaTime;

        if(countdown <= 0)
        {

       TrackMovenemntTime -= Time.deltaTime;
     // get rotation script reference and stop rotation
        BossRotation = FindAnyObjectByType<BossEnemyRotation>();

        BossRotation.NoRotation();

        Vector2 Direction = BossRotation.transform.right;

        transform.Translate(Direction * speed * Time.deltaTime);
        BossAnimations.SetBool("TransitionToRush",true);

            if (!PlayRushMoveSound)
            {
                PlayRushMoveSound = true;
                PlayMosquitoWingSound = false;
                FindAnyObjectByType<AudioManager>().PlaySounds("MosquitoRush");

            }
           
// this essentially creates a loop. Boss moves then stops then rotates to where the player is then moves again etc
          if(TrackMovenemntTime <= 0)
            {
                //StopBossMovenment();
                PlayRushMoveSound = false;
                if (!PlayMosquitoWingSound)
                {
                    PlayMosquitoWingSound = true;
                  FindAnyObjectByType<AudioManager>().PlaySounds("MosquitoWingFlap");
                }
                
                BossRotation.TurnOnRotation();
                BossAnimations.SetBool("TransitionToRush",false);
                countdown = tickRate;
                TrackMovenemntTime = MovenmentTimeTickRate;
            }

        }

    }
 

   //Collision Detection for when the boss gets hit, flag so it checks once when the boss is hit
void OnCollisionEnter2D(Collision2D collision)
    {
        //Adding a boolean so that we can only take damage once per collision
        if(collision.gameObject.tag == "Bullet")
        {
            BossHealth = FindAnyObjectByType<BossHealthScript>();
            Destroy(collision.gameObject);
            GameObject BloodAnimation = Instantiate(BloodSplatter,transform.position,quaternion.identity);
            Destroy(BloodAnimation, 0.5f);            

            if (!IsBossHit)
            {
                IsBossHit = true;
                BossHealth.BossTakesDmg(PlayerBulletDmg); 
                FindAnyObjectByType<AudioManager>().PlaySounds("EnemyDeath");

            }
            else
            {
                IsBossHit = false;
            }
        }

        if(collision.gameObject.tag == "Player")
        {
// I have a flag here so that health is only deducted once, as soon as the player is hit
          
           frogHealth = FindAnyObjectByType<HealthScript>();

            if (!IsPlayerHit)
            {
                IsPlayerHit = true;
                frogHealth.TakeDamageFromEnemy(BossDamage);

            }
            else
            {
                // so that the player can be hit multiple times
                IsPlayerHit = false;
            }

        }
    }

    public void KillBoss()
    {
        Destroy(gameObject);
    }

    void BossConstraints()
    {
        //Clamp so the boss dosent fly off the screen

        Vector3 Barrier = transform.position;

        Barrier.x = Mathf.Clamp(transform.position.x,Leftwall.x + offset,Rightwall.x - offset);

        Barrier.y = Mathf.Clamp(transform.position.y,floor.y + offset,ceiling.y - offset);

        transform.position = Barrier;
    }

    public float IncreaseBossSpeed(float speedIncrease)
    {
        speed += speedIncrease;
        return speedIncrease;
    }

}
