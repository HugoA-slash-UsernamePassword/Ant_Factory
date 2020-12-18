using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBoundary : MonoBehaviour
{
    [SerializeField] private Editor editor;
    private void OnTriggerExit2D () {
        editor.UnsetTiles();
    }
}
