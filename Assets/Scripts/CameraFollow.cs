using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public float damping;

   public Transform target;
   Vector3 Velocity = Vector3.zero;

    void Update()
    {
       
       CameraFollowPlayer();
    }

    void CameraFollowPlayer()
    {
         if(target != null)
        {
        Vector3 TargetPos = target.position;
        TargetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position,TargetPos, ref Velocity, damping);

        }

        




    }


}
