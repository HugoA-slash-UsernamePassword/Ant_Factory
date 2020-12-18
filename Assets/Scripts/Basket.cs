using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Basket : MonoBehaviour
{
    [SerializeField] private int buildIndex;

    [SerializeField] private Layer[] targetLayers;

    private void OnTriggerEnter2D (Collider2D col) {
        if (col.tag == "Egg") {
            if (CheckEgg(col.gameObject)) {
                SceneManager.LoadScene(buildIndex);
            }
        }
    }

    private bool CheckEgg (GameObject egg) {
        Egg eggScript = egg.GetComponent<Egg>();

        int solidLayerSortingOrder = eggScript.layers[0].sortingOrder;

        for (int i = 0; i < targetLayers.Length; i++) {
            Layer targetLayer = targetLayers[i];
            SpriteRenderer eggLayer = eggScript.PatternToLayer(targetLayer.GetPattern());

            if (3 - i != eggLayer.sortingOrder) { // Check position
                Debug.Log("wrong sorting order, expected " + (4 - i) + ", got " + eggLayer.sortingOrder);
                return false;
            }

            if (eggScript.PatternToSprite(targetLayer.GetPattern()) != eggLayer.sprite) { // Check pattern
                Debug.Log("wrong pattern, expected " + eggScript.PatternToSprite(targetLayer.GetPattern()) + ", got " + eggLayer.sprite);
                return false;
            }

            if (!targetLayer.GetColor().Equals(eggLayer.color)) { // Check color
                Debug.Log("wrong color, expected " + targetLayer.GetColor() + ", got " + eggLayer.color);
                return false;
            }
        }

        return true;
    }

    [System.Serializable]
    private class Layer {
        public Egg.Pattern pattern;
        public Color color;
        public Layer (Egg.Pattern pattern, Color color) {
            this.pattern = pattern;
            this.color = color;
        }

        public Egg.Pattern GetPattern () {
            return pattern;
        }

        public Color GetColor () {
            return color;
        }
    }
}
