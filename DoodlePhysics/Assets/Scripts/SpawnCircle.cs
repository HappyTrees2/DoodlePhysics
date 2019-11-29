using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCircle : MonoBehaviour
{
    // Spawner tutorial: https://www.youtube.com/watch?v=appPNl_Q0xE

    public GameObject circle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)  
                Instantiate(circle, touchPos, Quaternion.identity);          
        }
    }
}
