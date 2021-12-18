using System.Collections;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    // Script Basic Settings (Do Not Change)
    [Header("Unity Stuff")]
    [SerializeField]
    private GameObject enemy;

    void Start() {
        StartCoroutine(EnemySpawner());
    }

    IEnumerator EnemySpawner() {
        while (true) {
            Instantiate(enemy, new Vector3(Random.Range (0f, 25f), 2f, Random.Range(-25f, 0f)), Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }
}
