using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    void Update()
    {
     
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPos.y < 0f)
        {
            Destroy(gameObject);
        }



    }
}
