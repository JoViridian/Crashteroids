using UnityEngine;

public class MyOffScreenDestroy : MonoBehaviour
{
    public float immunityTime;
    private float immunityCountdown = 1;
    public SphereCollider sphereBuffer;
    private float padding = 0.01f;

    private void Awake()
    {
        immunityCountdown = immunityTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (immunityCountdown < 0)
        {
            // right of screen
            if (Camera.main.WorldToScreenPoint(new Vector3(transform.position.x - sphereBuffer.radius - padding, 0, 0)).x > Screen.width)
            {
                Destroy(gameObject);
            }

            // left of screen
            if (Camera.main.WorldToScreenPoint(new Vector3(transform.position.x + sphereBuffer.radius + padding, 0, 0)).x < 0f)
            {
                Destroy(gameObject);
            }

            // top of screen
            if (Camera.main.WorldToScreenPoint(new Vector3(0, 0, transform.position.z - sphereBuffer.radius - padding)).y > Screen.height)
            {
                Destroy(gameObject);
            }

            // bottom of screen
            if (Camera.main.WorldToScreenPoint(new Vector3(0, 0, transform.position.z + sphereBuffer.radius + padding)).y < 0f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            immunityCountdown -= Time.deltaTime;
        }
    }
}
