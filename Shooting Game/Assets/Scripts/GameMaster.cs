using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    // Script Basic Settings (Do Not Change)
    [Header("Unity Stuff")]
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject area;
    private float shrinkSpeed = 0.02f;
    [SerializeField]
    private Text timerText;
    private float timer;

    void Start() {
        StartCoroutine(EnemySpawner());
    }

    void Update() {
        timer += Time.deltaTime;
        UpdateTimerUI(timer);
        if (area.transform.localScale.x < 0 || area.transform.localScale.z < 0) {
            return;
        }
        AreaShrink();

    }

    IEnumerator EnemySpawner() {
        while (true) {
            Instantiate(enemy, new Vector3(Random.Range (0f, 25f), 2f, Random.Range(-25f, 0f)), Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }

    void UpdateTimerUI(float time) {
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);
        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        timerText.text = currentTime[0].ToString() + currentTime[1].ToString() + ":" + currentTime[2].ToString() + currentTime[3].ToString();
    }

    void AreaShrink() {
        area.transform.localScale = new Vector3(area.transform.localScale.x - shrinkSpeed * Time.deltaTime, area.transform.localScale.y, area.transform.localScale.z - shrinkSpeed * Time.deltaTime);
    }
}
