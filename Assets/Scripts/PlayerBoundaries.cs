using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    private float SpriteWidth;
    private float SpriteHeigth;

    [SerializeField]
    private Cat cat = null;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        SpriteWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        SpriteHeigth = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!cat.IsDead)
        {
            Vector3 viewPosition = transform.position;
            viewPosition.x = Mathf.Clamp(viewPosition.x, screenBounds.x + 0.09f, -screenBounds.x - SpriteWidth);
            viewPosition.y = Mathf.Clamp(viewPosition.y, screenBounds.y + SpriteHeigth, -screenBounds.y - SpriteHeigth);
            transform.position = viewPosition;
        }
    }
}
