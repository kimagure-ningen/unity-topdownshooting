using System.Collections;
using UnityEngine;

public class AreaDamage : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(10f * Time.deltaTime);
        }
    }
}
