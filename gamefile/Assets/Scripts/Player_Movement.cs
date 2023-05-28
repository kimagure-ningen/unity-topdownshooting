using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // Unique Settings
    private float speed = 4f;
    private float mapRadius = 12.5f; // Needs to be a square

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.z < mapRadius) {
                transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.z > -mapRadius) {
                transform.position -= new Vector3(0, 0, speed) * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > -mapRadius) {
                transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < mapRadius) {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
        }
    }
}
