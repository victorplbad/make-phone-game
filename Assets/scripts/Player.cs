using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public int moveSpeed = 5;
    Rigidbody2D rb;

    public InputSys inputSystem;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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

            SceneManager.LoadScene(0);
        
        }

        
    }



}
