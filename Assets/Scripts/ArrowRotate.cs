using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotate : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    void Update()
    {
        

        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * -1);
    }
}
