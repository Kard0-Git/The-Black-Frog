using System.Threading;
using UnityEngine;

public class BossFollowPointScript : MonoBehaviour
{
  
 public float pointSpeed = 7;


    void Update()
    {

    }
    public void MovePoint()
    {
        transform.Translate(Vector2.right * pointSpeed * Time.deltaTime);
        
    }

   
}
