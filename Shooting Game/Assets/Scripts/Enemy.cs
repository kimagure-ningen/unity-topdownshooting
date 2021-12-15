using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnCollisionEnter(Collision collider) {
        if (collider.gameObject.tag == "Bullet") {
            // * Damage Enemy
        }
    }
}
