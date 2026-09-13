using UnityEngine;

public class RotatePivot : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
    Vector3 CurrentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    Vector3 rotationOrigin = (CurrentMousePos - transform.position).normalized;
     
     float RotationAngle = Mathf.Atan2(rotationOrigin.y,rotationOrigin.x) * Mathf.Rad2Deg;

     transform.rotation = Quaternion.Euler(0,0,RotationAngle);

   

    }

    

  
}
