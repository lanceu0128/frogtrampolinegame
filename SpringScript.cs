using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }
}
