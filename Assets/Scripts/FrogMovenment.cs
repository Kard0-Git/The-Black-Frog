using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FrogMovenment : MonoBehaviour
{
    public float speed;

    public GameObject left,right,ceiling,floor;

  

    public float offset;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveFrog();
        BoundryDetection();
       
    }

    Vector2 Movenment(Vector2 MoveDirection)
    {
        transform.Translate(MoveDirection * speed * Time.deltaTime);
        return MoveDirection;
    }

    

    void MoveFrog()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Movenment(Vector2.up);
       
        }

        if (Input.GetKey(KeyCode.A))
        {
            Movenment(Vector2.left);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Movenment(Vector2.down);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Movenment(Vector2.right);
        }
    }


   void BoundryDetection()
    {
        Vector2 NewBoundry = transform.position;

        NewBoundry.x = Mathf.Clamp(transform.position.x,left.transform.position.x + offset,right.transform.position.x - offset);
        NewBoundry.y = Mathf.Clamp(transform.position.y,floor.transform.position.y + offset,ceiling.transform.position.y - offset);

        transform.position = NewBoundry;
    }


  public void KillPlayer()
    {
        Destroy(gameObject);
    }
    

    
    
}


