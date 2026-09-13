using System;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckEnemyAmount : MonoBehaviour
{

bool AllEnemiesDead = false;
[SerializeField] private int waves;


void Update()
    {
        
    }


//checking if all enemies that are a child of this transform are basically gone
public void CheckEnemyCount()
    {
        //Go to the next scene when the childcount reaches 0
        if(transform.childCount <= 0)
        {
           AllEnemiesDead = true;
           

           SceneManager.LoadScene("Wave one");
//hello
        }
        else 
        {
            AllEnemiesDead = false;
        }
    }
}
