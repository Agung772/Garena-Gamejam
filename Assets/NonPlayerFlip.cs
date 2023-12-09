using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerFlip : MonoBehaviour
{
    string flip;

    public Transform[] flipTranforms;

    [SerializeField] Animator animator;
    private void Update()
    {
        if (flip != "Right")
        {
            flip = "Right";

            for (int i = 0; i < flipTranforms.Length; i++)
            {
                flipTranforms[i].transform.localPosition = new Vector3(0, 0, -0.05f);
                flipTranforms[i].transform.rotation = Quaternion.Euler(0, 0, 0);
            }

        }
        else if (flip != "Left")
        {
            flip = "Left";
            for (int i = 0; i < flipTranforms.Length; i++)
            {
                flipTranforms[i].transform.localPosition = new Vector3(0, 0, -0.05f);
                flipTranforms[i].transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else if (flip != "Idle")
        {
            flip = "Idle";

        }
    }
}
