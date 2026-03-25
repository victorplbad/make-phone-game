using TMPro;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    [SerializeField] DodgerAttributes playerStats;
    public GameObject[] enemyPrefab;
    public Player playersCharter;
    
    public float spawnRate = 5;
    private bool gameStarted = false;
    //int score = 0;

    public float spawnRange = 1f;

    Vector2 screenPos;

    public TextMeshProUGUI scoreText;


    public GameData gameData;
    public PlayerData playerData;

    public float currentTime;
    public Transform currentPlayerPositionX;
    public int currentPlayerScore;
    public int currentPlayerHealth;
    
    public Transform playerItSelf;

    




    void SpawnEnemy()
    {

        float randomX = Random.Range(spawnRange, 0f);

        Vector2 viewPortPos = new Vector2(randomX, 1f);

        Vector2 worldPos = Camera.main.ViewportToWorldPoint(viewPortPos);

        
        Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], worldPos, Quaternion.identity);

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

        currentPlayerScore = playerStats.currentScore;
        currentPlayerHealth = playersCharter.myHP;
        currentPlayerPositionX = playerItSelf;
        currentTime += Time.deltaTime; // + playerData.time;
    }


    void UpdateText(int score)
    {
        scoreText.text = score.ToString();
    }






    public void LoadToObject()
    {


        currentTime = playerData.time;
        currentPlayerPositionX = playerData.playerPositionX;
        currentPlayerScore = playerData.playerScore;
        currentPlayerHealth = playerData.playerHealth;




    }







}
