using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    private Vector2 screenBounds;
    private float spriteWidth;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        spriteWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        this.transform.position += new Vector3(-0.4f, 0.0f, 0.0f) * Time.deltaTime;
        if (transform.position.x+spriteWidth < screenBounds.x)
        {
            this.transform.position += new Vector3(spriteWidth*3-0.05f, 0.0f, 0.0f);
        }
    }
}
