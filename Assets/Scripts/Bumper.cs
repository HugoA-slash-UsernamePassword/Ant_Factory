using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    private Animator animator;
    private AudioSource audio;

    private void Start () {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D (Collision2D col) {
        if (col.gameObject.tag == "Egg") {
            Bounce();
        }
    }

    void Bounce () {
        animator.SetTrigger("Bounce");
        audio.Play();
    }
}
