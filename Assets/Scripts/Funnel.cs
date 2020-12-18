using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funnel : MonoBehaviour
{
    [SerializeField] private Funnel otherFunnelScript;
    [SerializeField] private float timeDisabled;
    [SerializeField] private Transform holdingPoint;

    private bool disabled = false;

    private void OnTriggerEnter2D (Collider2D col) {
        if (col.tag == "Egg" && !disabled) {
            otherFunnelScript.DisableFunnel();
            col.transform.position = otherFunnelScript.holdingPoint.position;
        }
    }

    public void DisableFunnel () {
        StartCoroutine(Disable());
    }

    private IEnumerator Disable () {
        disabled = true;

        float timer = 0;

        while (timer < timeDisabled) {
            timer += Time.deltaTime;
            yield return null;
        }

        disabled = false;
    }
}
