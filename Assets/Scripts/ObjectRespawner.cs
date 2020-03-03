using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRespawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public GameObject starPrefab;
    public float spawnTimeAsteroid, spawnTimeStar;
    private float timeAsteroid, timeStar;
    private float time;

    [SerializeField]
    private Cat cat = null;
    void Start()
    {
        time = 0;
        timeAsteroid = 0;
        timeStar = 0;
        spawnTimeAsteroid = 2.0f;
        spawnTimeStar = 6.0f;
    }

    private void spawnAsteroid()
    {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = new Vector2(2.0f, Random.Range(-0.7f, 0.7f));

    }

    private void spawnStar()
    {
        GameObject s = Instantiate(starPrefab) as GameObject;
        s.transform.position = new Vector2(2.0f, Random.Range(-0.7f, 0.7f));
    }
    // Update is called once per frame
    void Update()
    {
        if (!cat.IsDead)
        {
            time += Time.deltaTime;
            if (time > 5.0f && spawnTimeAsteroid > 0.2f)
            {
                spawnTimeAsteroid -= 0.1f;
                time = 0;
            }
            timeAsteroid += Time.deltaTime;
            if (timeAsteroid > spawnTimeAsteroid)
            {
                spawnAsteroid();
                timeAsteroid = 0;
            }
            timeStar += Time.deltaTime;
            if (timeStar - 1.0f > spawnTimeStar)
            {
                spawnStar();
                timeStar = 0;
            }
        }
    }
}
