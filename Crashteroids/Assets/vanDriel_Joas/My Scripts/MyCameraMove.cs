using UnityEngine;

public class MyCameraMove : MonoBehaviour
{
    private Rigidbody rb;
    public Camera cam;
    public float followCam = 0.5f;

    private Vector3 vectorFix;
    private Vector3 camFix;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
   
    void Update()
    {
        vectorFix = GameManagerAltered.playerPosition;
        vectorFix.y = transform.position.y;
        rb.linearVelocity = followCam * (vectorFix - transform.position) + (vectorFix - transform.position);
        camFix = transform.position;
        camFix.y = 10;
        cam.transform.position = camFix;

    }
}
