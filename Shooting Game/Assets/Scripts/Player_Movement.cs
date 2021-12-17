using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // Unique Settings
    private float speed = 4f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, 0, speed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
    }
}
