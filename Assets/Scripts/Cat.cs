using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public Animator animator;
    private AudioSource audioSource;
    private GameManager gameManager;
    private Rigidbody2D rb;
    public GameObject explosionPrefab;

    private bool isDead;
    public bool IsDead
    {
        get
        {
            return isDead;
        }
    }

    void Start()
    {
        isDead = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!IsDead)
        {
            if (Input.GetAxis("Horizontal") != 0) animator.SetFloat("Movement", 1);
            else if (Input.GetAxis("Vertical") != 0) animator.SetFloat("Movement", 1);
            else animator.SetFloat("Movement", 0);
            Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            transform.position += horizontal * Time.deltaTime;
            Vector3 vertical = new Vector3(0.0f, Input.GetAxis("Vertical"), 0.0f);
            transform.position += vertical * Time.deltaTime;
        }
        else
        {
            transform.Rotate(0.0f, 0.0f, -0.2f);
        }
    }

    private void Explode()
    {
        GameObject expl = Instantiate(explosionPrefab) as GameObject;
        expl.transform.position = this.transform.position + new Vector3(0.2f, 0.0f, 0.0f);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("asteroid"))
        {
            StartCoroutine(Die());
        }
    }
    private IEnumerator Die()
    {
        if (!isDead)
        {
            isDead = true;
            animator.SetFloat("Die", 1);
            audioSource.Stop();
            Explode();
            rb.gravityScale = 0.01f;
            this.gameObject.tag = "DeadPlayer";
            yield return new WaitForSeconds(2);
            GameTextManager.Instance.CreateText();
            //gameManager.EndGame();
        }
    }
}
