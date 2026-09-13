using UnityEngine;

public class AmmoShootingScript : MonoBehaviour
{
    public float ammo_speed;

    void Update()
    {
        MoveAmmo();
    }
    void MoveAmmo()
    {
        transform.Translate(Vector2.right * ammo_speed * Time.deltaTime);
    }
}
