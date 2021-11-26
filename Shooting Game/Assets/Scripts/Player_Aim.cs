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

        // Character Rotation
        Vector3 mouse_RedefinedPos = new Vector3(mouse_WorldPos.x, transform.position.y, mouse_WorldPos.z);
        Vector3 lookRotation = mouse_RedefinedPos - transform.position;
        transform.rotation = Quaternion.LookRotation(lookRotation, Vector3.up);

        // Line Renderer Rotation
        Vector3 normalized_Pos = (mouse_RedefinedPos - transform.position).normalized * 2.0f;
        Vector3 line_EndPos = new Vector3(normalized_Pos.x + transform.position.x, 2f, normalized_Pos.z + transform.position.z);
        aim_Line.SetPosition(0, gameObject.transform.position);
        aim_Line.SetPosition(1, line_EndPos);
    }
}
