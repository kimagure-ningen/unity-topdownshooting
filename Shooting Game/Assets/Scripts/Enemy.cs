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

    void Start()
    {
        health = startHealth;
        healthBar.maxValue = startHealth;
        healthBar.value = health;
    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            TakeDamage(collider.gameObject.GetComponent<Bullet>().bulletDamage);
            Destroy(collider.gameObject);
        }
    }

    void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.value = health;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
