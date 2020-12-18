using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Basket : MonoBehaviour
{
    [SerializeField] private int buildIndex;

    private void OnTriggerEnter2D (Collider2D col) {
        if (col.tag == "Egg") {
            SceneManager.LoadScene(buildIndex);
        }
    }
}
