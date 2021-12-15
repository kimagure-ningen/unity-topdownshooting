using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject playerMesh;
    Player_Shoot script;
    Vector3 bulletDestination;
    private float bulletSpeed = 0.025f;
    void Start()
    {
        playerMesh = GameObject.Find("Player_Mesh");
        script = playerMesh.GetComponent<Player_Shoot>();
        bulletDestination = script.bulletDestination;

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
