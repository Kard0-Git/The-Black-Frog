using System;
using TMPro;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckEnemyAmount : MonoBehaviour
{

bool AllEnemiesDead = false;

SpawnBossEnemy SpawnBoss;


public int wave_incriment = 1;
TMP_Text wave_text;

GameTextHandler Game_UI;

bool UpdateWaveCount = false;


void Start()
    {
        wave_text = GameObject.Find("WaveText").GetComponent<TMP_Text>();
        Game_UI = FindAnyObjectByType<GameTextHandler>();
    }
void Update()
    {
        
    }


//checking if all enemies that are a child of this transform are basically gone
public void CheckEnemyCount()
    {
        //Go to the next scene when the childcount reaches 0
        if(transform.childCount <= 0)
        {
          
            if (!UpdateWaveCount)
            {
                UpdateWaveCount = true;
                UpdateWave();

            }
          
        }


    }


 void UpdateWave()
    {
            wave_incriment++;

            SpawnBoss = FindAnyObjectByType<SpawnBossEnemy>();


          wave_text.text = $"Wave: {wave_incriment}";

          wave_text.enabled = true;

         Game_UI.EnableBossText();
          SpawnBoss.SpawnBoss();

      

      

      


    }
}
