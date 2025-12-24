using UnityEngine;

public class MyStabilizer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    { 
        if (Mathf.Abs(transform.eulerAngles.x) > 2 || Mathf.Abs(transform.eulerAngles.z) > 2)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }
}
