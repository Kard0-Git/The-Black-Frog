using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class ToungeLineRenderer : MonoBehaviour
{

    LineRenderer lr;

    public float LineDeletionTime;
    AmmoBehavior ammoBehavior;

    BulletSpawner bulletSpawner;

    GameTextHandler ammoText;


    Vector3 point;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        bulletSpawner = FindAnyObjectByType<BulletSpawner>();
        ammoText = FindAnyObjectByType<GameTextHandler>();
      
    }

    // Update is called once per frame
    void Update()
    {
        mouseControls();
      
    }

    void mouseControls()
    {
        //Tounge mechanism was much easier than I thought
        if (Input.GetMouseButton(0))
        {
            point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            lr.SetPosition(0,transform.position);
            lr.SetPosition(1,point);

            CheckToungeCollision();
          
        }

        Destroy(gameObject,LineDeletionTime);

        
    }

    void CheckToungeCollision()
    {
 
      Collider2D Ammo = Physics2D.OverlapBox(point,Vector2.zero,0f,LayerMask.GetMask("Ammo"));

// if there is a collider, delete the gameobject its attached to
        if(Ammo != null)
        {
     
        Destroy(Ammo.gameObject);
        bulletSpawner.AddBullets();
        ammoText.UpdateAmmo();



            
        }

     
}

}