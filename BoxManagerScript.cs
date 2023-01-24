using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxManagerScript : MonoBehaviour
{

    // box activation variables
    private GameObject[] boxes;
    private GameObject currentBox;
    private BoxScript boxScript;
    public float timer = 10f;
    public int score = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        boxes = GameObject.FindGameObjectsWithTag("box");
        boxSelector();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        
        if (timer > 0) {
            timer -= Time.deltaTime;
        } else {
            boxSelector();
            timer = 10f;
        }
    }

    private void boxSelector() {

        int index = Random.Range(0, boxes.Length);

        if (boxes[index] != currentBox) {
            // activate NEW box
            boxScript = boxes[index].GetComponent<BoxScript>();
            boxScript.activate();

            // activate OLD box
            if (currentBox != null) {
                boxScript = currentBox.GetComponent<BoxScript>();
                boxScript.deactivate();
            }

            currentBox = boxes[index];
            
        } else {
            boxSelector();
        }

        Debug.Log("New Box Activated: " + currentBox.name);
    }
}
