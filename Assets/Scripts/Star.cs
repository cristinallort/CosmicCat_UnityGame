using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private Vector2 screenBounds;
    public float scoreValue;
    private Score score;
    void Start()
    {
        score = GameObject.FindObjectOfType<Score>();
        scoreValue = 1.5f;
        speed = 2.0f;
        rb = this.GetComponent<Rigidbody2D>();
        audioSource = this.GetComponent<AudioSource>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, speed);
        rb.velocity = new Vector2(-speed * 0.3f, 0.0f);
        if (transform.position.x < screenBounds.x)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            score.UpdateScore(scoreValue);
            rb.position = new Vector2(-1.5f, -2f);
        }
    }
}
