using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Action : MonoBehaviour
{
    Camera mainCam;
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mainCam.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
            if(hit.collider != null)
            {
                Debug.Log("Target name: " + hit.collider.name);
            }
        }
    }
}
