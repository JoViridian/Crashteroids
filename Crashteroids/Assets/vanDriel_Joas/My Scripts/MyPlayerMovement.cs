using UnityEngine;

public class MyPlayerMovement : MonoBehaviour
{
    public Rigidbody rocket;
    public Animator animator;
    public int spinPower = 180;
    public int forwardPower = 360;

    void Update()
    {
        if (Input.GetKey(GameManagerAltered.Instance.script.keyTurnRight))
        {
            transform.Rotate(0, spinPower * Time.deltaTime, 0);
        }

        if (Input.GetKey(GameManagerAltered.Instance.script.keyTurnLeft))
        {
            transform.Rotate(0, -spinPower * Time.deltaTime, 0);
        }

        if (Input.GetKey(GameManagerAltered.Instance.script.keyForward))
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
