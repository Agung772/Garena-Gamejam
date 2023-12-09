using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    float horizontal;
    float vertical;

    string flip;

    public Transform[] flipTranforms;

    [SerializeField] Animator animator;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        float move = new Vector2 (horizontal, vertical).magnitude;

        if (move > 0)
        {
            animator.SetBool("Run", true);
        }
        else if (move == 0)
        {
            animator.SetBool("Run", false);
        }

        if (horizontal != 0)
        {
            animator.SetFloat("Flip", horizontal);
        }


        if (horizontal > 0 && flip != "Right")
        {
            flip = "Right";

            for (int i = 0; i < flipTranforms.Length; i++)
            {
                flipTranforms[i].transform.localPosition = new Vector3(0, 0, -0.05f);
                flipTranforms[i].transform.rotation = Quaternion.Euler(0, 0, 0);
            }

        }
        else if (horizontal < 0 && flip != "Left")
        {
            flip = "Left";
            for (int i = 0; i < flipTranforms.Length; i++)
            {
                flipTranforms[i].transform.localPosition = new Vector3(0, 0, -0.05f);
                flipTranforms[i].transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else if (horizontal == 0 && flip != "Idle")
        {
            flip = "Idle";

        }
    }
}
