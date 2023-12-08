using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject projectilePrefab;

    public Transform pointRight, pointLeft;

    public float inputMouseY;

    bool right;
    Transform target;
    new Transform camera;
    void Start()
    {
        target = transform.parent;
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;

        transform.parent = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!right)
            {
                right = true;
                GameObject projectileObject = Instantiate(projectilePrefab, pointLeft.position, pointLeft.rotation);
                projectileObject.GetComponent<Rigidbody>().AddForce(transform.forward * 50, ForceMode.Impulse);
            }
            else
            {
                right = false;
                GameObject projectileObject = Instantiate(projectilePrefab, pointRight.position, pointRight.rotation);
                projectileObject.GetComponent<Rigidbody>().AddForce(transform.forward * 50, ForceMode.Impulse);
            }

        }

        float mouseY = Input.GetAxis("Mouse Y");
        inputMouseY += mouseY * 100 * Time.deltaTime;

        inputMouseY = Mathf.Clamp(inputMouseY, -30, 30);

        transform.position = Vector3.MoveTowards(transform.position, target.position, 50 * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(-inputMouseY, camera.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-inputMouseY, camera.eulerAngles.y, 0), 50 * Time.deltaTime);

    }
}
