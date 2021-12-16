using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Script Basic Settings (Do Not Change)
    [Header("Unity Stuff")]
    [SerializeField]
    private Slider healthBar;

    // Unique Settings
    private float startHealth = 100f;
    private float health;

    void Start() {
        health = startHealth;
    }
    void OnCollisionEnter(Collision collider) {
        if (collider.gameObject.tag == "Bullet") {
            // * Get bullet damage amout and Damage Enemy
        }
    }
}
