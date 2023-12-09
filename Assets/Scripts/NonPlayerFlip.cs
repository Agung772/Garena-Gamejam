using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerFlip : MonoBehaviour
{
    string flip;

    public Transform[] flipTranforms;

    [SerializeField] Animator animator;

    public void SetFlip(string value)
    {
        if (value == "Right")
        {
            for (int i = 0; i < flipTranforms.Length; i++)
            {
                flipTranforms[i].transform.localPosition = new Vector3(0, 0, -0.05f);
                flipTranforms[i].transform.rotation = Quaternion.Euler(0, 0, 0);
                animator.SetBool("Right", true);
            }
        }
        else if (value == "Left")
        {
            for (int i = 0; i < flipTranforms.Length; i++)
            {
                flipTranforms[i].transform.localPosition = new Vector3(0, 0, -0.05f);
                flipTranforms[i].transform.rotation = Quaternion.Euler(0, 180, 0);
                animator.SetBool("Right", false);
            }
        }
    }
}
