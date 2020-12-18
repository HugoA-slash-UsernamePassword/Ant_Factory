using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    private Animator animator;

    private void Start () {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D (Collision2D col) {
        if (col.gameObject.tag == "Egg") {
            Bounce();
        }
    }

    void Bounce () {
        animator.SetTrigger("Bounce");
    }
}
