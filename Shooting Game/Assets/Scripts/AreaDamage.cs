using System.Collections;
using UnityEngine;

public class AreaDamage : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        Debug.Log("Hit!");
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Hit!");
            other.gameObject.GetComponent<Enemy>().TakeDamage(10f * Time.deltaTime);
        }
    }
}
