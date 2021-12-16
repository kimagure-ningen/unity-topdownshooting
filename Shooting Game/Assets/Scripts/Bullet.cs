using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Script Basic Settings (Do Not Change)
    private Player_Shoot playerShootScript;
    private Vector3 bulletDestination;

    // Unique Settings
    private float bulletSpeed = 0.025f;
    private float bulletDamage = 10f;

    void Start()
    {
        playerShootScript = GameObject.Find("Player_Mesh").GetComponent<Player_Shoot>();
        bulletDestination = playerShootScript.bulletDestination;

    }
    void Update()
    {
        if (transform.position == bulletDestination)
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, bulletDestination, bulletSpeed);
    }
}
