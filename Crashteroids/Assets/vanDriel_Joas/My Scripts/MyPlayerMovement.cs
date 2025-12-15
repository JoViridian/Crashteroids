using UnityEngine;

public class MyPlayerMovement : MonoBehaviour
{
    public Rigidbody rocket;
    public Animator animator;
    public int spinPower = 180;
    public int forwardPower = 360;

    void Update()
    {
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, spinPower * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -spinPower * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rocket.AddRelativeForce(0, 0, forwardPower * Time.deltaTime);
            //animator.SetBool("Thrusting", true);
        }
        else
        {
            //animator.SetBool("Thrusting", false);
        }
    }
}
