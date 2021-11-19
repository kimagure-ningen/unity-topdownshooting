using UnityEngine;

public class Player_Aim : MonoBehaviour
{
    [SerializeField]
    private GameObject aim_LineRenderer;
    LineRenderer aim_Line;
    Vector3 mouse_WorldPos;

    void Start()
    {
        aim_Line = aim_LineRenderer.GetComponent<LineRenderer>();
    }

    void Update()
    {
        int layerMask = LayerMask.GetMask(new string[] { "Environment" });

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            mouse_WorldPos = hit.point;
            Debug.Log(mouse_WorldPos);
        }

        Vector3 target_Pos = new Vector3(mouse_WorldPos.x, transform.position.y, mouse_WorldPos.z);
        Vector3 lookRotation = target_Pos - transform.position;
        transform.rotation = Quaternion.LookRotation(lookRotation, Vector3.up);


        aim_Line.SetPosition(0, gameObject.transform.position);
        aim_Line.SetPosition(1, target_Pos);
    }
}
