using UnityEngine;
using UnityEngine.InputSystem;
using gyro = UnityEngine.InputSystem.Gyroscope;
using UnityEngine.SceneManagement;

public class Sensors_Gyroscope : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 5f;
    public GameObject player;
    public bool gyroOff = true;


    void Awake()
    {
        if (gyro.current != null)
        {
            InputSystem.EnableDevice(gyro.current);
            rb = gameObject.GetComponent<Rigidbody2D>();

        }
        else
        {
         gyroOff = false;
        }

    }



    void Update()
    {
        if (gyro.current != null)
        {
            
            Vector3 rotationRate = gyro.current.angularVelocity.ReadValue();
            

            Debug.Log("Rotation Rate: " + rotationRate);

            Vector3 rotationDegrees = rotationRate * Mathf.Rad2Deg;


            
            player.transform.TransformDirection(rotationDegrees);


            //player.transform.Translate(rotationDegrees.x, rotationDegrees.y, 0f * Time.deltaTime);
            //rb.linearVelocityX = moveDir * moveSpeed;
        }
        
    }
}
