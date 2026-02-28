using UnityEditor;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float gravityScale = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = gravityScale;
    }

    void Update()
    {
     
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPos.y < 0f)
        {
            Destroy(gameObject);
        }



    }
}
