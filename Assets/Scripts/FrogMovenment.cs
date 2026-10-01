using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FrogMovenment : MonoBehaviour
{
    public float speed;

    public GameObject left,right,ceiling,floor;
    
    Animator animator;

     bool TurnOffMusic = false;
  

    public float offset;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = FindAnyObjectByType<Animator>();

      
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
            animator.SetBool("IsMoving", true);
       
        }

      else if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("IsMoving",false);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            Movenment(Vector2.left);
            animator.SetBool("IsMoving",true);
        }
         else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("IsMoving",false);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            Movenment(Vector2.down);
            animator.SetBool("IsMoving",true);
        }
         else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("IsMoving",false);
        }
         

        if (Input.GetKey(KeyCode.D))
        {
            Movenment(Vector2.right);
            animator.SetBool("IsMoving",true);
        }
         else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("IsMoving",false);
        }


        // If we are not moving play idle animation
       
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


