using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;



public class Player : MonoBehaviour
{

    [SerializeField] DodgerAttributes playerStats;

    public int moveSpeed = 5;
    Rigidbody2D rb;
    


    public InputSys inputSystem;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        int myHP = playerStats.maximumHealth;
    }

    // Update is called once per frame
    void Update()
    {

        float moveDir = 0f;
        Vector2 screennPos;

        if (inputSystem.IsPressing(out screennPos)) 
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(screennPos.x, screennPos.y, 0f));

            if (touchPos.x < 0)
            {
                moveDir = -1f;
                Debug.Log("venstre");
            }
            else
            {
                moveDir = 1f;
                Debug.Log("højre");
            }
          

        }


        Vector3 viewportPos = Camera.main.WorldToViewportPoint(rb.position);

        if (viewportPos.x <= 0f && moveDir < 0f || viewportPos.x >= 1f && moveDir > 0f)
        {
            moveDir = 0f;
        }

        rb.linearVelocityX = moveDir * moveSpeed;



    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            int myHP = playerStats.currentHealth;


            if (myHP <= 0)
            {
                playerStats.currentScore = 0; // set score to 0
                myHP = playerStats.maximumHealth; // restart hp pool
                SceneManager.LoadScene(0); // game over
            }
            else
            {
                myHP--;
            }

            playerStats.currentHealth = myHP;

        }

        


    }



}
