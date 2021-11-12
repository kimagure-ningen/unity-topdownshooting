using UnityEngine;

public class Player_Aim : MonoBehaviour
{
    Vector3 worldPosition;

    void Update()
    {
        int layerMask = LayerMask.GetMask(new string[] { "Environment" });

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            worldPosition = hit.point;
            Debug.Log(worldPosition);
        }

        Vector3 lookRotation = new Vector3(worldPosition.x, transform.position.y, worldPosition.z) - transform.position;
        transform.rotation = Quaternion.LookRotation(lookRotation, Vector3.up);
    }
}
