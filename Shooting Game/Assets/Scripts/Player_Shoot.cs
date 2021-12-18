using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    // Script Basic Settings (Do Not Change)
    [Header("Unity Stuff")]
    [SerializeField]
    private GameObject aimLineRenderer;
    private LineRenderer aimLine;
    [SerializeField]
    private GameObject bulletPrefab;
    private Vector3 mouseWorldPos;
    public Vector3 bulletDestination;

    // Unique Settings
    private float range = 4.0f;
    private float fireRate = 2.5f;
    private bool canFire;
    private Color reloadColor = new Color(70f / 255f, 70f / 255f, 70f / 255f, 0.3f);
    private Color readyFireColor = new Color(0f / 255f, 176f / 255f, 10f / 255f, 0.5f);
    private Color canFireColor = new Color(70f / 255f, 70f / 255f, 70f / 255f, 0.8f);

    void Start()
    {
        aimLine = aimLineRenderer.GetComponent<LineRenderer>();
        canFire = true;
        aimLine.startColor = canFireColor;
        aimLine.endColor = canFireColor;
        aimLine.startWidth = 1f;
        aimLine.endWidth = 1f;
    }

    void Update()
    {
        // Point Ray at the Ground
        int layerMask = LayerMask.GetMask(new string[] { "Environment" });

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            mouseWorldPos = hit.point;
        }

        // Character Rotation
        Vector3 mouse_RedefinedPos = new Vector3(mouseWorldPos.x, transform.position.y, mouseWorldPos.z);
        Vector3 lookRotation = mouse_RedefinedPos - transform.position;
        transform.rotation = Quaternion.LookRotation(lookRotation, Vector3.up);

        // Line Renderer Rotation
        Vector3 normalized_Pos = (mouse_RedefinedPos - transform.position).normalized * range;
        Vector3 line_EndPos = new Vector3(normalized_Pos.x + transform.position.x, transform.position.y, normalized_Pos.z + transform.position.z);
        aimLine.SetPosition(0, gameObject.transform.position);
        aimLine.SetPosition(1, line_EndPos);

        // Shoot
        if (Input.GetMouseButtonDown(0))
        {
            if (canFire == true)
            {
                bulletDestination = line_EndPos;
                GameObject bulletGameObject = (GameObject)Instantiate(bulletPrefab, transform.position, new Quaternion(0, 0, 0, 0));
                StartCoroutine(Firerate());
            }
        }

        if (canFire == false && aimLine.startWidth < 1f && aimLine.endWidth < 1f)
        {
            aimLine.startWidth += 1f / fireRate * Time.deltaTime;
            aimLine.endWidth += 1f / fireRate * Time.deltaTime;
        }
    }

    IEnumerator Firerate()
    {
        canFire = false;
        aimLine.startWidth = 0f;
        aimLine.endWidth = 0f;
        aimLine.startColor = reloadColor;
        aimLine.endColor = reloadColor;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
        aimLine.startColor = readyFireColor;
        aimLine.endColor = readyFireColor;
        yield return new WaitForSeconds(0.25f);
        aimLine.startColor = canFireColor;
        aimLine.endColor = canFireColor;
    }
}
