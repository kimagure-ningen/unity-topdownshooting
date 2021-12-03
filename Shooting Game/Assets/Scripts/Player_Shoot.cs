using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject aim_LineRenderer;
    private float range = 3.0f;
    LineRenderer aim_Line;
    Vector3 mouse_WorldPos;
    [SerializeField]
    private GameObject bulletPrefab;

    void Start()
    {
        aim_Line = aim_LineRenderer.GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Point Ray at the Ground
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
        Vector3 normalized_Pos = (mouse_RedefinedPos - transform.position).normalized * range;
        Vector3 line_EndPos = new Vector3(normalized_Pos.x + transform.position.x, transform.position.y, normalized_Pos.z + transform.position.z);
        aim_Line.SetPosition(0, gameObject.transform.position);
        aim_Line.SetPosition(1, line_EndPos);

        // Shoot
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletGameObject = (GameObject)Instantiate(bulletPrefab, transform.position, new Quaternion(0, 0, 0, 0));
            Bullet bulletScript = bulletGameObject.GetComponent<Bullet>();
            bulletGameObject.transform.position = Vector3.MoveTowards(transform.position, line_EndPos, 20);

            // * Shoot bullet development next!
        }
    }
}
