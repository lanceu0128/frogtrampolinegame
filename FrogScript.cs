using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    public Rigidbody2D frogBody;
    
    public float vertStrength;
    public float horizStrength;
    private Camera gameCam;
    private BoxManagerScript boxManager;
    private FrogSpawnerScript frogSpawner;
    private Vector3 frogPos;

    // Start is called before the first frame update
    void Start()
    {
        boxManager = GameObject.FindGameObjectWithTag("allboxes").GetComponent<BoxManagerScript>();
        frogSpawner = GameObject.FindGameObjectWithTag("logic").GetComponent<FrogSpawnerScript>();
        gameCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        checkIfOffScreen();
        checkIfStationary();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "spring") {
            frogBody.velocity = new Vector2(collision.gameObject.transform.rotation.z * horizStrength, vertStrength);

            // Debug.Log("Collision Detected");
        }

        if (collision.gameObject.tag == "box") {
            frogBody.velocity = new Vector2(- frogBody.velocity.x, frogBody.velocity.y);
        }

        if (collision.gameObject.tag == "activebox") {
            frogBody.velocity = new Vector2(- frogBody.velocity.x, frogBody.velocity.y);

            boxManager.score += 1;
            Destroy(gameObject);
            frogSpawner.despawnFrog(false);
            Debug.Log("Score increased to" + boxManager.score); // replace
        }
    } 

    private void checkIfOffScreen() {
        // WorldToViewportPoint returns position in relation to camera
        frogPos = gameCam.WorldToViewportPoint(gameObject.transform.position);

        if (frogPos.y < -0.1) {
            Destroy(gameObject);
            frogSpawner.despawnFrog(true);
            Debug.Log("Frog went off screen at last coords " + frogPos);
        }
    }

    private void checkIfStationary() {
        frogPos = gameCam.WorldToViewportPoint(gameObject.transform.position);

        if (frogBody.velocity.x == 0 && frogBody.velocity.y == 0) {
            Destroy(gameObject);
            frogSpawner.despawnFrog(false);
            Debug.Log("Frog Died to Stationary at last coords " + frogPos);
        }
    }
}
