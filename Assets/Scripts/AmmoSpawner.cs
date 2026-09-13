using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{

    public List<GameObject> AmmoDrops;
    public Transform Left,right,floor,Ceiling;
    public float offset;

    public Transform AmmoDropHolder;



    void Start()
    {
        SpawnAmmoDrops();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAmmoDrops()
    {
        foreach(GameObject i in AmmoDrops)
        {
            Vector3 pos = new Vector3(Random.Range(Left.transform.position.x + offset,right.transform.position.x - offset),
            Random.Range(floor.transform.position.y + offset,Ceiling.transform.position.y - offset),0);
            Instantiate(i,pos,Quaternion.identity,AmmoDropHolder);
        }
    }
}
