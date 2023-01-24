using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringSpawnerScript : MonoBehaviour
{
    public GameOverScript gameOverScript;
    public GameObject springObject;
    private bool isDown;
    private Vector3 mousePos;
    private Vector3 firstPos;
    private Vector3 secondPos;
    private Vector3 finalPos;
    private float angle;
    private List<GameObject> currentSprings;

    // Start is called before the first frame update
    void Start()
    {
        currentSprings = new List<GameObject>();
        currentSprings.Add(Instantiate(springObject, new Vector3(0,-1,0), Quaternion.Euler(0, 0, 0)));

        gameOverScript = GameObject.FindGameObjectWithTag("logic").GetComponent<GameOverScript>();

        // set z in start since it is never used
        mousePos.z = transform.position.z;
        finalPos.z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSprings.Count > 3) {
            Destroy(currentSprings[0]);
            currentSprings.RemoveAt(0);
        }

        if (gameOverScript.isGameOver == false) {
            mouseController();
        }
    }

    private void mouseController() {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !isDown) {
            isDown = true;
            firstPos = mousePos;
        }
            
        if (Input.GetMouseButtonUp(0)) {
            spawnSpring(springObject);
            isDown = false;
        }
    }

    private void spawnSpring(GameObject spring) {
        secondPos = mousePos;

        finalPos.x = (secondPos.x + firstPos.x) / 2;
        finalPos.y = (secondPos.y + firstPos.y) / 2;

        if (firstPos.x < secondPos.x) {
            angle = Mathf.Atan2(secondPos.y - firstPos.y , secondPos.x - firstPos.x) * Mathf.Rad2Deg;
        } else {
            angle = Mathf.Atan2(firstPos.y - secondPos.y , firstPos.x - secondPos.x) * Mathf.Rad2Deg;
        }

        currentSprings.Add(Instantiate(spring, finalPos, Quaternion.Euler(0, 0, angle)));
        Debug.Log("Spring Created at Coords: " + finalPos + ", Angle: " + angle);
    }
}
