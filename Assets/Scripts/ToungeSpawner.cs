using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class ToungeSpawner : MonoBehaviour
{

   Transform lineParent;

   public GameObject Tounge_Prefab;


    void Start()
    {
 
    }
    void Update()
    {
        GetMousPos();
    }

    void GetMousPos()
    {
        if (Input.GetMouseButtonDown(0))
        {
                Instantiate(Tounge_Prefab,transform.position,Quaternion.identity);
            
        }
    }
}
