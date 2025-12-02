using UnityEngine;

public class MyScreenLoop : MonoBehaviour
    
{
    public SphereCollider sphereBuffer;
    private float padding = 0.01f;

    void Update()
    {
        // looppoint for right of screen
        if (Camera.main.WorldToScreenPoint(new Vector3(transform.position.x - sphereBuffer.radius, 0, 0)).x > Screen.width)
        {
            transform.position += new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(0,0)).x - sphereBuffer.radius + padding, 0, 0) * 2;
        }

        // looppoint for left of screen
        if (Camera.main.WorldToScreenPoint(new Vector3(transform.position.x + sphereBuffer.radius, 0, 0)).x < 0f)
        {
            transform.position += new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x + sphereBuffer.radius - padding, 0, 0) * 2;
        }

        // looppoint for top of screen
        if (Camera.main.WorldToScreenPoint(new Vector3(0, 0, transform.position.z - sphereBuffer.radius)).y > Screen.height)
        {
            transform.position += new Vector3(0, 0, Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).z - sphereBuffer.radius + padding) * 2;
        }

        // looppoint for bottom of screen
        if (Camera.main.WorldToScreenPoint(new Vector3(0, 0, transform.position.z + sphereBuffer.radius)).y < 0f)
        {
            transform.position += new Vector3(0, 0, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height)).z + sphereBuffer.radius - padding) * 2;
        }
    }
}
