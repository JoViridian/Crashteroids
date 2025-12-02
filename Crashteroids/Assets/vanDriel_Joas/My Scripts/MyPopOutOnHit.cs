using UnityEngine;

public class MyPopOutOnHit : MonoBehaviour
{
    public GameObject effectHit;
  
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(effectHit, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
