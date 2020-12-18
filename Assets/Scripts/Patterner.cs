using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patterner : MonoBehaviour
{
    [SerializeField] private Egg.Pattern pattern;

    private Animator animator;

    void Start()
    {
        // *** Sprite needs to reflect pattern
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.tag == "Egg") {
            animator.SetTrigger("Stamp");
            // Should this also hold the egg while it is stamped
            col.GetComponent<Egg>().ApplyPattern(pattern);
        }
    }
}
