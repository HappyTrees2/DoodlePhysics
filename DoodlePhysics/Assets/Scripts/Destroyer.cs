using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroyer Tutorial: https://www.youtube.com/watch?v=appPNl_Q0xE

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
