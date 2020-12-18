using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patterner : MonoBehaviour
{
    [SerializeField] private Egg.Pattern pattern;

    private Animator animator;

    [SerializeField] GameObject layerPrefab;
    [SerializeField] Transform layerSpawnPoint;
    [SerializeField] Sprite nonePattern;
    [SerializeField] Sprite spotsPattern;
    [SerializeField] Sprite stripesPattern;
    [SerializeField] Sprite specklesPattern;

    void Start()
    {
        animator = GetComponent<Animator>();

        GameObject layerObject = Instantiate(layerPrefab, layerSpawnPoint.position, layerSpawnPoint.rotation, transform);

        SpriteRenderer layerSpriteRend = layerObject.GetComponent<SpriteRenderer>();
        
        layerSpriteRend.sprite = PatternToSprite(pattern);
        layerSpriteRend.color = new Color(1, 1, 1, 0.5f);
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.tag == "Egg") {
            animator.SetTrigger("Stamp");

            col.GetComponent<Egg>().ApplyPattern(pattern);
        }
    }

    private Sprite PatternToSprite (Egg.Pattern pattern) {
        switch (pattern) {
            case Egg.Pattern.None: return nonePattern;
            case Egg.Pattern.Spots: return spotsPattern;
            case Egg.Pattern.Stripes: return stripesPattern;
            case Egg.Pattern.Speckles: return specklesPattern;
            default: throw new ArgumentOutOfRangeException();
        }
    }
}
