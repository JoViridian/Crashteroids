using UnityEngine;

public class MyCameraMove : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rb;
    private Rigidbody rbPlayer;
    public Camera cam;
    public float followCamMult = 1;
    private float vectorFix = 5.2f;

    private Vector3 playerPos;
    private Vector3 camFix;
    private Vector3 screenSize;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rbPlayer = player.GetComponent<Rigidbody>();
    }
   
    void Update()
    { 
        if (rbPlayer != null)
        {
            screenSize = (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)) - Camera.main.ScreenToWorldPoint(new Vector3(0, 0))) * 0.5f;

            // get player position
            playerPos = player.transform.position;
            playerPos.y = transform.position.y;

            // calculate the catchup speed and vector
            rb.linearVelocity = new Vector3((playerPos - transform.position).x / screenSize.x, 0, (playerPos - transform.position).z / screenSize.z) * vectorFix * followCamMult;
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }

        camFix = transform.position;
        camFix.y = 10;
        cam.transform.position = camFix;
    }
}
