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
        if (editor.egg)
        {
            transform.position = Vector3.Lerp(transform.position, editor.egg.transform.position, .25f);
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 8, 0.15f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector2(25, 5), .25f);
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 24, 0.15f);
        }
        //else transform.position = Vector3.Lerp(transform.position, new Vector3((Screen.width-Input.mousePosition.x)/Screen.width*56-6,(Screen.height-Input.mousePosition.y)/Screen.height*75-25) , 0.05f);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6, 50), Mathf.Clamp(transform.position.y, -50, 50), -10);
    }
}
