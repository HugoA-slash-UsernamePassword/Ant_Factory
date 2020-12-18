using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    [SerializeField] private Color color;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = color;
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.tag == "Egg") {
            col.GetComponent<Egg>().Paint(color);
        }
    }
}
