using TMPro;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    [SerializeField] DodgerAttributes playerStats;

    public GameObject enemyPrefab;

    public float spawnRate = 5;

    bool gameStarted = false;

    int score = 0;

    public float spawnRange = 1f;

    Vector2 screenPos;

    public TextMeshProUGUI scoreText;

    void SpawnEnemy()
    {

        float randomX = Random.Range(0f, spawnRange);

        Vector2 viewPortPos = new Vector2(randomX, 1f);

        Vector2 worldPos = Camera.main.ViewportToWorldPoint(viewPortPos);

        Instantiate(enemyPrefab, worldPos, Quaternion.identity);

        playerStats.currentScore++;

        UpdateText(playerStats.currentScore);
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnEnemy", 0.5f, spawnRate); // call X , start after X , repeat X
    }


    private void Update()
    {
        if (transform.GetComponent<InputSys>().IsPressing(out screenPos) && !gameStarted)
        {
            StartSpawning();
            gameStarted = true;
        }
    }


    void UpdateText(int score)
    {
        scoreText.text = score.ToString();
    }



}
