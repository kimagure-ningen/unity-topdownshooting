using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject playerMesh;
    Player_Shoot script;
    Vector3 bullet_Destination;
    void Start()
    {
        playerMesh = GameObject.Find("Player_Mesh");
        script = playerMesh.GetComponent<Player_Shoot>();
        bullet_Destination = script.bulletDestination;

    }
    void Update()
    {
        if (transform.position == bullet_Destination)
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, bullet_Destination, 0.2f);
    }
}
