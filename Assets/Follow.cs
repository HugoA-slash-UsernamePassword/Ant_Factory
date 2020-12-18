using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Editor editor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (editor.egg) transform.position = Vector3.Lerp(transform.position, editor.egg.transform.position, .25f);
        else transform.position = Vector3.Lerp(transform.position, new Vector3((Screen.width-Input.mousePosition.x)/Screen.width*56-6,(Screen.height-Input.mousePosition.y)/Screen.height*100-50) , 0.05f);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6, 50), Mathf.Clamp(transform.position.y, -50, 50), -10);
    }
}
