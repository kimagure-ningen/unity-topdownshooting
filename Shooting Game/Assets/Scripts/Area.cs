using System.Collections;
using UnityEngine;

public class Area : MonoBehaviour
{
    private bool toxicatedArea;
    private bool toxicatedArea1;
    private bool toxicatedArea2;
    private bool toxicatedArea3;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(10f * Time.deltaTime);
        }
    }
}
