using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public enum Pattern {None, Spots, Stripes, Speckles};
    public static int numOfPatterns = System.Enum.GetValues(typeof(Pattern)).Length;

    [SerializeField] private Pattern pattern = Pattern.None;

    public SpriteRenderer[] layers = new SpriteRenderer[numOfPatterns];

    [SerializeField] GameObject layerPrefab;
    [SerializeField] Sprite nonePattern;
    [SerializeField] Sprite spotsPattern;
    [SerializeField] Sprite stripesPattern;
    [SerializeField] Sprite specklesPattern;

    void Start () {
        for (int i = 0; i < numOfPatterns; i++) {
            GameObject layerObject = Instantiate(layerPrefab, transform);

            layerObject.name = ((Pattern) i).ToString();

            layers[i] = layerObject.GetComponent<SpriteRenderer>();
            
            layers[i].sprite = PatternToSprite((Pattern) i);

            layers[i].sortingOrder = numOfPatterns - i - 1;
        }
    }

    public void ApplyPattern (Pattern newPattern) {
        pattern = newPattern;
    }

    public void Paint (Color color) {
        SpriteRenderer targetLayer = PatternToLayer(pattern);

        int oldSortingOrderOfTarget = targetLayer.sortingOrder;

        foreach (SpriteRenderer layer in layers) {
            if (layer.sortingOrder > oldSortingOrderOfTarget) {
                layer.sortingOrder--;
            }
        }

        targetLayer.color = color;
        targetLayer.sortingOrder = numOfPatterns - 1;
    }

    public SpriteRenderer PatternToLayer (Pattern pattern) {
        return layers[(int) pattern];   
    }

    public Sprite PatternToSprite (Pattern pattern) {
        switch (pattern) {
            case Pattern.None: return nonePattern;
            case Pattern.Spots: return spotsPattern;
            case Pattern.Stripes: return stripesPattern;
            case Pattern.Speckles: return specklesPattern;
            default: throw new ArgumentOutOfRangeException();
        }
    }
}
