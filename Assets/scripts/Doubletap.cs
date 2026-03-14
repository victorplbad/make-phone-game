using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class Doubletap : MonoBehaviour
{

    [SerializeField] GameObject Player;
    [SerializeField] float maxTapDelay = 0.3f;

    float lastTapTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (touch.activeTouches.Count < 1)
            return;

        var touch1 = touch.activeTouches[0];

        if (touch1.phase == UnityEngine.InputSystem.TouchPhase.Began)
        {
            float timeSinceLastTap = Time.time - lastTapTime;

            if (timeSinceLastTap <= maxTapDelay)
            {
                // Double tap detected!
                Player.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
                lastTapTime = 0f; // reset
            }
            else
            {
                lastTapTime = Time.time;
            }
        }
    }
}