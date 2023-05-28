using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Script Basic Settings (Do Not Change)
    [Header("Unity Stuff")]
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private GameObject player;

    private NavMeshAgent _agent;

    // Unique Settings
    private float startHealth = 100f;
    private float health;

    void Start()
    {
        health = startHealth;
        healthBar.maxValue = startHealth;
        healthBar.value = health;

        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
        _agent.destination = player.transform.position;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            TakeDamage(collider.gameObject.GetComponent<Bullet>().bulletDamage);
            Destroy(collider.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.value = health;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
