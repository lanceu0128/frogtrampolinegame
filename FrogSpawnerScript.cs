using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogSpawnerScript : MonoBehaviour
{
    public GameOverScript gameOverScript;
    public GameObject frogObject;
    public Text livesText;
    public int lives;
    private float randomX;
    private float timer = 5f;
    private List<GameObject> currentFrogs;

    // Start is called before the first frame update
    void Start()
    {
        currentFrogs = new List<GameObject>();
        currentFrogs.Add(Instantiate(frogObject, new Vector3(0,0.75f,0), Quaternion.Euler(0, 0, 0)));
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "x" + lives.ToString();
        if (lives <= 0) {
            gameOverScript.gameOver();
        }

        if (currentFrogs.Count < 1) {
            spawnFrog();
        }

        if (timer > 0) {
            timer -= Time.deltaTime;
        } else {
            spawnFrog();
            timer = 5f;
        }
    }

    private void spawnFrog() {
        randomX = Random.Range(-0.4f,0.4f);
        currentFrogs.Add(Instantiate(frogObject, new Vector3(gameObject.transform.position.x + randomX, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.Euler(0, 0, 0)));

        // frogBody = currentFrogs[currentFrogs.Count-1].GetComponent<Rigidbody2D>();
        // frogBody.AddForce(new Vector2(randomForce, 0));
        
        Debug.Log("Frog Spawned at X: " + randomX);
    }

    public void despawnFrog(bool liveLost) {
        currentFrogs.RemoveAt(0);

        if (liveLost && lives != 0) {
            lives -= 1;
        }
    }
}
