using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedPlayer;
    public float maxSpeed;

    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Vector3 move;
    public new Rigidbody rigidbody;
    public new Transform camera;



    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(inputX, 0, inputZ).normalized;

        if (direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y; ;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //move = new Vector3(inputX, 0, inputZ);

            rigidbody.AddForce(moveDir * speedPlayer * 10 * Time.deltaTime);
        }




        //Maksimal speed player
        if (rigidbody.velocity.x > maxSpeed) rigidbody.velocity = new Vector3(maxSpeed, rigidbody.velocity.y, rigidbody.velocity.z);
        if (rigidbody.velocity.x < -maxSpeed) rigidbody.velocity = new Vector3(-maxSpeed, rigidbody.velocity.y, rigidbody.velocity.z);

        if (rigidbody.velocity.z > maxSpeed) rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, maxSpeed);
        if (rigidbody.velocity.z < -maxSpeed) rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, -maxSpeed);
    }
}
