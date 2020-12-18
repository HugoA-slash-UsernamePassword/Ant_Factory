using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldAndEject : MonoBehaviour
{
    [SerializeField] private float ejectTime;
    [SerializeField] private float ejectDelay;
    [SerializeField] private float ejectSpeed;

    [SerializeField] private float ejectCooldown;

    [SerializeField] private Transform holdingPoint;

    private Animator animator;

    private Coroutine ejectRoutine;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.tag == "Egg") {
            if (ejectRoutine == null) {
                ejectRoutine = StartCoroutine(Eject(col));
            }
        }
    }

    IEnumerator Eject (Collider2D col) {
        float timer  = 0;

        Rigidbody2D eggRB = col.GetComponent<Rigidbody2D>();

        col.gameObject.SetActive(false);

        while (timer < ejectTime) {
            timer += Time.deltaTime;
            yield return null;
        }

        animator.SetTrigger("Eject");

        timer = 0;

        while (timer < ejectDelay) {
            timer += Time.deltaTime;
            yield return null;
        } 

        col.transform.position = holdingPoint.position;
        col.gameObject.SetActive(true);

        eggRB.velocity = Vector2.zero;

        eggRB.AddForce(transform.up * ejectSpeed, ForceMode2D.Impulse);
        
        timer = 0;

        while (timer < ejectCooldown) {
            timer += Time.deltaTime;
            yield return null;
        }

        ejectRoutine = null;
    }
}
