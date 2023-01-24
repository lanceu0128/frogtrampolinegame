using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public GameObject top;
    public GameObject middle;
    public GameObject bottom;
    private SpriteRenderer topSprite;
    private SpriteRenderer middleSprite;
    private SpriteRenderer bottomSprite;

    public void activate() {
        topSprite = top.GetComponent<SpriteRenderer>();
        middleSprite = middle.GetComponent<SpriteRenderer>();
        bottomSprite = bottom.GetComponent<SpriteRenderer>();

        topSprite.color = new Color(1, 1, 0, 1);
        middleSprite.color = new Color(1, 1, 0, 1);
        bottomSprite.color = new Color(1, 1, 0, 1);
        gameObject.tag = "activebox";
    }
    
    public void deactivate() {
        topSprite.color = new Color(1, 1, 1, 1);
        middleSprite.color = new Color(1, 1, 1, 1);
        bottomSprite.color = new Color(1, 1, 1, 1);
        gameObject.tag = "box";
    }
}
